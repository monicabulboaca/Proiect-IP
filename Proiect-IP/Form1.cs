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
        private IDatabaseParser _parser;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            // string fileContent = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|json files (*.json)|*.json";
            openFileDialog.FilterIndex = 2;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;


            }

            // check extension
            string fileExtension = filePath.Split('.')[1];
            switch(fileExtension)
            {
                case "csv":
                    _parser = new CSVDatabase();
                    if (CSVDatabase.IsCSV(filePath))
                        MessageBox.Show("Is CSV");
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

        private void saveFileButton_Click(object sender, EventArgs e)
        {

        }

        private void quitEditsButton_Click(object sender, EventArgs e)
        {

        }
    }
}
