using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_IP
{
    public partial class PreferencesForm : Form
    {
        private static string _fileExtension;
        public PreferencesForm()
        {
            InitializeComponent();
            _fileExtension = "csv";
        }

        public static string Extension
        {
            get
            {
                return _fileExtension;
            }
        }

        private void radioButtonCSV_Click(object sender, EventArgs e)
        {
            _fileExtension = "csv";
        }

        private void radioButtonXML_Click(object sender, EventArgs e)
        {
            _fileExtension = "xml";
        }

        private void radioButtonJSON_Click(object sender, EventArgs e)
        {
            _fileExtension = "json";
        }
    }
}
