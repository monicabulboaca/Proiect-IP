using Proiect_IP.DatabaseParser;
using Proiect_IP.DatabaseSavers;
using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect_IP
{
    public partial class Form1 : Form
    {
        private List<string> fieldNames;
        private List<Row> records;
        
        private IDatabaseParser _parser;
        private IDatabaseModeler _modeler;
        private IDatabaseSave _save;

        private EditRowForm editRowForm;
        private PreferencesForm prefForm;

        private int _editRowNumber;

        public Form1()
        {
            InitializeComponent();
            editRowForm = new EditRowForm(this);
            prefForm = new PreferencesForm();
            this.dataGridTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTable_CellClick);
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|json files (*.json)|*.json";
            openFileDialog.FilterIndex = 1;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                // check extension
                string fileExtension = filePath.Split('.')[1];

                switch (fileExtension)
                {
                    case "csv":
                        _parser = new CSVDatabase();
                        try
                        {
                            _parser.Parse(filePath, out fieldNames, out records);
                            _modeler = new DatabaseModeler(fieldNames, records);
                            SetupDataGridView();
                        }
                        catch(Exception ex)
                        {
                            string title = "Eroare fișier";
                            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "xml":
                        _parser = new XMLDatabase();
                        if (XMLDatabase.IsXML(filePath))
                        {
                            _parser.Parse(filePath, out fieldNames, out records);
                            _modeler = new DatabaseModeler(fieldNames, records);
                            SetupDataGridView();
                        }
                        else
                            MessageBox.Show("Is not XML");
                        break;
                    case "json":
                        _parser = new JSONDatabase();
                        try
                        {
                            _parser.Parse(filePath, out fieldNames, out records);
                            _modeler = new DatabaseModeler(fieldNames, records);
                            SetupDataGridView();
                        }
                        catch (Newtonsoft.Json.JsonReaderException ex)
                        {
                            string title = "Eroare fișier";
                            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
                        }
                        catch (Exception ex)
                        {
                            string title = "Eroare fișier";
                            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "sql":
                        _parser = new SQLiteDatabase();
                        break;
                    default:
                        _parser = new SQLiteDatabase();
                        break;
                }
            }

        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < dataGridTable.Rows.Count; i++)
            {
                for (int j = 0; j < fieldNames.Count; j++)
                {
                    _modeler.UpdateData(i, j, (string)dataGridTable[j, i].Value);
                }
            }*/

            string filePath = string.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|json files (*.json)|*.json";
            string defaultExtension = PreferencesForm.Extension;
            saveFileDialog.FilterIndex = defaultExtension == "csv" ? 1 : (defaultExtension == "xml" ? 2 : (defaultExtension == "json" ? 3 : 1));
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                string fileExtension = filePath.Split('.')[1];
                switch (fileExtension)
                {
                    case "csv":
                        _save = new CSVSaver();
                        _save.Save(filePath, _modeler.GetFields(), _modeler.GetRecords());
                        break;
                    case "json":
                        _save = new JSONSaver();
                        _save.Save(filePath, _modeler.GetFields(), _modeler.GetRecords());
                        break;
                    case "xml":
                        //_save = new XMLSaver();
                        _save.Save(filePath, _modeler.GetFields(), _modeler.GetRecords());
                        break;
                }
            }
        }

        private void quitEditsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridTable_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridTable.ColumnCount - 1) // edit button
                {
                    this.dataGridTable.ReadOnly = false;
                    
                    SetupDataGridViewRowEdit(editRowForm, e);
                    _editRowNumber = e.RowIndex;
                    editRowForm.ShowDialog();

                }
                else if (e.ColumnIndex == dataGridTable.ColumnCount - 2) // delete button
                {
                    string message = "Sunteți sigur că vreți să ștergeți rândul?";
                    string title = "Ștergere rând";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.dataGridTable.AllowUserToDeleteRows = true;
                        this.dataGridTable.Rows[e.RowIndex].Selected = true;
                        this.dataGridTable.Rows.RemoveAt(e.RowIndex);

                        string[] rowData = new string[records[e.RowIndex].Data.Count];
                        for (int j = 0; j < records[e.RowIndex].Data.Count; j++)
                        {
                            rowData[j] = this.dataGridTable.Rows[e.RowIndex].Cells[j].Value.ToString();
                        }
                        List<string> listRowData = new List<string>(rowData);
                        Row row = new Row();
                        row.Data = listRowData;
                        this._modeler.DeleteData(row);
                    }
                }
                this.dataGridTable.ReadOnly = true;
            }
        }

        private void SetupDataGridViewRowEdit(EditRowForm form, DataGridViewCellEventArgs e)
        {
            form.GetDataGridViewRowEdit().ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            form.GetDataGridViewRowEdit().ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            form.GetDataGridViewRowEdit().ColumnHeadersDefaultCellStyle.Font = new Font(this.dataGridTable.Font, FontStyle.Bold);
            this.dataGridTable.ReadOnly = false;
            form.GetDataGridViewRowEdit().AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            form.GetDataGridViewRowEdit().AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            form.GetDataGridViewRowEdit().ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            form.GetDataGridViewRowEdit().CellBorderStyle = DataGridViewCellBorderStyle.Single;
            form.GetDataGridViewRowEdit().GridColor = Color.Black;
            form.GetDataGridViewRowEdit().RowHeadersVisible = false;
            form.GetDataGridViewRowEdit().SelectionMode = DataGridViewSelectionMode.CellSelect;
            form.GetDataGridViewRowEdit().AllowUserToDeleteRows = false;
            form.GetDataGridViewRowEdit().Rows.Clear();
            form.GetDataGridViewRowEdit().Columns.Clear();
            form.GetDataGridViewRowEdit().ColumnCount = fieldNames.Count;
            for (int i = 0; i < fieldNames.Count; i++)
            {
                form.GetDataGridViewRowEdit().Columns[i].Name = fieldNames[i];
            }
            string[] row = new string[records[e.RowIndex].Data.Count];

            for (int j = 0; j < records[e.RowIndex].Data.Count; j++)
            {
                row[j] = records[e.RowIndex].Data[j];
            }
            form.GetDataGridViewRowEdit().Rows.Add(row);
        }

        private void SetupDataGridView()
        {
            this.dataGridTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            this.dataGridTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridTable.ColumnHeadersDefaultCellStyle.Font = new Font(this.dataGridTable.Font, FontStyle.Bold);
            this.dataGridTable.ReadOnly = true;
            this.dataGridTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
            this.dataGridTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dataGridTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dataGridTable.GridColor = Color.Black;
            this.dataGridTable.RowHeadersVisible = false;
            this.dataGridTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTable.AllowUserToDeleteRows = false;
            this.dataGridTable.Rows.Clear();
            this.dataGridTable.Columns.Clear();
            this.dataGridTable.ColumnCount = fieldNames.Count;
            for(int i = 0; i < fieldNames.Count; i++)
            {
                this.dataGridTable.Columns[i].Name = fieldNames[i];
            }

            for (int i = 0; i < records.Count; i++)
            {
                string[] row = new string[records[i].Data.Count];
                for(int j = 0; j < records[i].Data.Count; j++)
                {
                    row[j]= records[i].Data[j]; 
                }
                this.dataGridTable.Rows.Add(row);
            }

            // add new column for delete and edit
            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
            {
                deleteBtn.Name = "delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true; 
                this.dataGridTable.Columns.Add(deleteBtn);
            }
            this.dataGridTable.Columns[this.dataGridTable.ColumnCount - 1].Width = 50;

            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
            {
                editBtn.Name = "edit";
                editBtn.HeaderText = "";
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                this.dataGridTable.Columns.Add(editBtn);
            }

            this.dataGridTable.Columns[this.dataGridTable.ColumnCount - 1].Width = 50;
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PreferencesForm prefForm = new PreferencesForm();
            prefForm.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editRowForm_ReclickRequest(object sender, EventArgs e)
        {

        }

        public void OkButtonEditRow()
        {
            string[] row = new string[records[_editRowNumber].Data.Count];
            for (int j = 0; j < records[_editRowNumber].Data.Count; j++)
            {
                row[j] = editRowForm.GetDataGridViewRowEdit().Rows[0].Cells[j].Value.ToString();
                this.dataGridTable.Rows[_editRowNumber].Cells[j].Value = row[j];
                this._modeler.UpdateData(_editRowNumber, j, row[j]);
            }
        }
    }
}
