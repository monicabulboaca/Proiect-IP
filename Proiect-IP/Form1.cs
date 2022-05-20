using Proiect_IP.DatabaseParser;
using Proiect_IP.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IP
{
    public partial class Form1 : Form
    {
        private List<string> fieldNames;
        private List<Row> records;
        
        private IDatabaseParser _parser;
        private IDatabaseModeler _modeler;

        public Form1()
        {
            InitializeComponent();

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|json files (*.json)|*.json";
            openFileDialog.FilterIndex = 2;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                // check extension
                string fileExtension = filePath.Split('.')[1];

                switch (fileExtension)
                {
                    case "csv":
                        _parser = new CSVDatabase();
                        if (CSVDatabase.IsCSV(filePath))
                        {
                            _parser.Parse(filePath, out fieldNames, out records);
                            _modeler = new DatabaseModeler(fieldNames, records);
                            SetupDataGridView();
                        }
                        else
                            MessageBox.Show("Is not CSV");
                        break;
                    case "xml":
                        _parser = new XMLDatabase();
                        break;
                    case "json":
                        _parser = new JSONDatabase();
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

        }

        private void quitEditsButton_Click(object sender, EventArgs e)
        {

        }

        private void SetupDataGridView()
        {
            this.dataGridTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            this.dataGridTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridTable.ColumnHeadersDefaultCellStyle.Font = new Font(this.dataGridTable.Font, FontStyle.Bold);

            this.dataGridTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
            this.dataGridTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.dataGridTable.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dataGridTable.GridColor = Color.Black;
            this.dataGridTable.RowHeadersVisible = false;
            this.dataGridTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // this.dataGridTable.Dock = DockStyle.Fill;

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
        }
    }
}
