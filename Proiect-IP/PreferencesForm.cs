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

            this.BackColor = Color.FromArgb(220, 220, 220);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
