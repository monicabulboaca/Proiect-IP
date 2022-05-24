using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect_IP
{
    public partial class Form1 : Form
    {
        private List<string> _fieldNames;
        private List<Interfaces.Row> _records;
        
        private Interfaces.IDatabaseParser _parser;
        private Interfaces.IDatabaseModeler _modeler;
        private Interfaces.IDatabaseSave _save;

        private EditRowForm _editRowForm;
        private PreferencesForm _preferencesForm;

        private int _editRowNumber;

        public Form1()
        {
            InitializeComponent();
            _editRowForm = new EditRowForm(this);
            _preferencesForm = new PreferencesForm();
            this.dataGridTable.CellClick += new DataGridViewCellEventHandler(this.dataGridTable_CellClick);
            this.openFileButton.BackColor = Color.FromArgb(168, 228, 160);
            this.saveFileButton.BackColor = Color.FromArgb(168, 228, 160);
            this.quitEditsButton.BackColor = Color.FromArgb(168, 228, 160);
            this.BackColor = Color.FromArgb(220, 220, 220);
            this.dataGridTable.BackgroundColor = Color.FromArgb(255, 255, 240);
        }

        /// <summary>
        /// Event that is triggered when user clicks on the "Load" button
        /// </summary>
        /// <param name="sender">Parameter for creating the reference of the object.</param>
        /// <param name="e">Parameter that containts the event data.</param>
        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        /// Event that is triggered when user clicks on the "Save as" button
        /// </summary>
        /// <param name="sender">Parameter for creating the reference of the object.</param>
        /// <param name="e">Parameter that containts the event data.</param>
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Event that is triggered when user clicks on the "Quit" button
        /// </summary>
        /// <param name="sender">Parameter for creating the reference of the object.</param>
        /// <param name="e">Parameter that containts the event data.</param>
        private void quitEditsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event that is triggered when user clicks on a cell in DataGridView.
        /// </summary>
        /// <param name="sender">Parameter for creating the reference of the object.</param>
        /// <param name="e">Parameter that containts the event data.</param>
        private void dataGridTable_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    if (e.ColumnIndex == dataGridTable.ColumnCount - 1) // edit button
                    {
                        this.dataGridTable.ReadOnly = false;

                        SetupDataGridViewRowEdit(_editRowForm, e);
                        _editRowNumber = e.RowIndex;
                        _editRowForm.ShowDialog();
                    }
                    else if (e.ColumnIndex == dataGridTable.ColumnCount - 2) // delete button
                    {
                        string message = "Are you sure you want to delete this row?";
                        string title = "Row deletion";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.dataGridTable.AllowUserToDeleteRows = true;
                            this.dataGridTable.Rows[e.RowIndex].Selected = true;
                            this.dataGridTable.Rows.RemoveAt(e.RowIndex);
                            _records.RemoveAt(e.RowIndex);

                            string[] rowData = new string[_records[e.RowIndex].Data.Count];
                            for (int j = 0; j < _records[e.RowIndex].Data.Count; j++)
                            {
                                rowData[j] = this.dataGridTable.Rows[e.RowIndex].Cells[j].Value.ToString();
                            }
                            List<string> listRowData = new List<string>(rowData);
                            Interfaces.Row row = new Interfaces.Row();
                            row.Data = listRowData;
                            this._modeler.DeleteData(row);
                        }
                    }
                    this.dataGridTable.ReadOnly = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
             }
                
        }

        /// <summary>
        /// Method that populates and styles the DataGridView for the pop up edit form
        /// </summary>
        /// <param name="form">The pop up form. </param>
        /// <param name="e">Parameter that containts the event data.</param>
        private void SetupDataGridViewRowEdit(EditRowForm form, DataGridViewCellEventArgs e)
        {
            form.GetDataGridViewRowEdit().EnableHeadersVisualStyles = false;
            form.GetDataGridViewRowEdit().ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 179, 113);
            form.GetDataGridViewRowEdit().ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            form.GetDataGridViewRowEdit().ColumnHeadersDefaultCellStyle.Font = new Font(this.dataGridTable.Font, FontStyle.Bold);
            this.dataGridTable.ReadOnly = false;
            form.GetDataGridViewRowEdit().AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            form.GetDataGridViewRowEdit().AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            form.GetDataGridViewRowEdit().RowHeadersVisible = false;
            form.GetDataGridViewRowEdit().SelectionMode = DataGridViewSelectionMode.CellSelect;
            form.GetDataGridViewRowEdit().AllowUserToDeleteRows = false;
            form.GetDataGridViewRowEdit().Rows.Clear();
            form.GetDataGridViewRowEdit().Columns.Clear();
            form.GetDataGridViewRowEdit().ColumnCount = _fieldNames.Count;
            form.GetDataGridViewRowEdit().DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 240);
            form.GetDataGridViewRowEdit().BorderStyle = BorderStyle.None;
            form.GetDataGridViewRowEdit().DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 240, 230);
            form.GetDataGridViewRowEdit().DefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 179, 113);
            for (int i = 0; i < _fieldNames.Count; i++)
            {
                form.GetDataGridViewRowEdit().Columns[i].Name = _fieldNames[i];
            }
            string[] row = new string[_records[e.RowIndex].Data.Count];

            for (int j = 0; j < _records[e.RowIndex].Data.Count; j++)
            {
                row[j] = _records[e.RowIndex].Data[j];
            }
            form.GetDataGridViewRowEdit().Rows.Add(row);
        }

        /// <summary>
        /// Method that populates and styles the DataGridView for the main form
        /// </summary>
        private void SetupDataGridView()
        {
            this.dataGridTable.EnableHeadersVisualStyles = false;
            this.dataGridTable.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 179, 113);
            this.dataGridTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridTable.ColumnHeadersDefaultCellStyle.Font = new Font(this.dataGridTable.Font, FontStyle.Bold);
            this.dataGridTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
            this.dataGridTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridTable.RowHeadersVisible = false;
            this.dataGridTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTable.AllowUserToDeleteRows = false;
            this.dataGridTable.Rows.Clear();
            this.dataGridTable.Columns.Clear();
            this.dataGridTable.ColumnCount = _fieldNames.Count;
            this.dataGridTable.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 240);
            this.dataGridTable.BorderStyle = BorderStyle.None;
            this.dataGridTable.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 240, 230);
            this.dataGridTable.DefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 179, 113);
            for (int i = 0; i < _fieldNames.Count; i++)
                this.dataGridTable.Columns[i].Name = _fieldNames[i];

            for (int i = 0; i < _records.Count; i++)
            {
                string[] row = new string[_records[i].Data.Count];
                for(int j = 0; j < _records[i].Data.Count; j++)
                {
                    row[j]= _records[i].Data[j]; 
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

        /// <summary>
        /// Event that is triggered when user presses the preferences tab in the menu.
        /// </summary>
        /// <param name="sender">Parameter for creating the reference of the object.</param>
        /// <param name="e">Parameter that containts the event data.</param>
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _preferencesForm.ShowDialog();
        }


        /// <summary>
        /// Event that is triggered when user presses the "Open file" tab in the submenu File.
        /// </summary>
        /// <param name="sender">Parameter for creating the reference of the object.</param>
        /// <param name="e">Parameter that containts the event data.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        /// Method that takes care of updating the DataGridTable after user clicked ok button in the pop up edit form
        /// </summary>
        public void OkButtonEditRow()
        {
            string[] row = new string[_records[_editRowNumber].Data.Count];
            for (int j = 0; j < _records[_editRowNumber].Data.Count; j++)
            {
                row[j] = _editRowForm.GetDataGridViewRowEdit().Rows[0].Cells[j].Value.ToString();
                this.dataGridTable.Rows[_editRowNumber].Cells[j].Value = row[j];
                this._modeler.UpdateData(_editRowNumber, j, row[j]);
            }
        }

        /// <summary>
        /// Method that loads a file and parses its content.
        /// </summary>
        private void OpenFile()
        {
            string filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|json files (*.json)|*.json";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                // check extension
                string fileExtension = filePath.Split('.')[1];

                switch (fileExtension)
                {
                    case "csv":
                        _parser = new CSV.CSVDatabase();
                        try
                        {
                            _parser.Parse(filePath, out _fieldNames, out _records);
                            _modeler = new Modeler.DatabaseModeler(_fieldNames, _records);
                            SetupDataGridView();
                        }
                        catch (Exception ex)
                        {
                            string title = "File error!";
                            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "xml":
                        _parser = new XML.XMLDatabase();
                        try
                        {
                            _parser.Parse(filePath, out _fieldNames, out _records);
                            _modeler = new Modeler.DatabaseModeler(_fieldNames, _records);
                            SetupDataGridView();
                        }
                        catch (Exception ex)
                        {
                            string title = "File error";
                            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "json":
                        _parser = new JSON.JSONDatabase();
                        try
                        {
                            _parser.Parse(filePath, out _fieldNames, out _records);
                            _modeler = new Modeler.DatabaseModeler(_fieldNames, _records);
                            SetupDataGridView();
                        }
                        //invalid json exception
                        catch (Newtonsoft.Json.JsonReaderException ex)
                        {
                            string title = "Invalid file!";
                            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
                        }
                        //general exception
                        catch (Exception ex)
                        {
                            string title = "File error!";
                            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                            DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Method that saves a file with certain extension.
        /// </summary>
        private void SaveFile()
        {
            string filePath = string.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|json files (*.json)|*.json";
            string defaultExtension = PreferencesForm.Extension;
            saveFileDialog.FilterIndex = defaultExtension == "csv" ? 1 : (defaultExtension == "xml" ? 2 : (defaultExtension == "json" ? 3 : 1));
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    string fileExtension = filePath.Split('.')[1];
                    switch (fileExtension)
                    {
                        case "csv":
                            _save =new CSV.CSVSaver();
                            _save.Save(filePath, _modeler.GetFields(), _modeler.GetRecords());
                            break;
                        case "json":
                            _save = new JSON.JSONSaver();
                            _save.Save(filePath, _modeler.GetFields(), _modeler.GetRecords());
                            break;
                        case "xml":
                            _save = new XML.XMLSaver();
                            _save.Save(filePath, _modeler.GetFields(), _modeler.GetRecords());
                            break;
                        default:
                            throw new Exception("Invalid extension! Please try .csv, .xml or .json!");
                    }
                    string title = "Save";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show("File saved successfully!", title, buttons, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                string title = "Invalid extension!";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(ex.Message, title, buttons, MessageBoxIcon.Exclamation);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Helper.chm");
        }

        private void dataGridTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
