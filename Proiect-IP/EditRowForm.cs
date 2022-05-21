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
    public partial class EditRowForm : Form
    {
        private bool okClicked = false;
        public EditRowForm()
        {
            InitializeComponent();
        }

        private void buttonOkEdit_Click(object sender, EventArgs e)
        {
            okClicked = true;
        }

        public DataGridView GetDataGridViewRowEdit()
        {
            return this.dataGridViewRowEdit;
        }

        public bool OkClicked()
        {
            if (okClicked)
                return true;
            else
                return false;
        }
    }
}
