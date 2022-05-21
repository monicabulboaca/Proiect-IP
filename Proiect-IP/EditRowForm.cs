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
        public bool buttonOkClicked = false;
        public EditRowForm()
        {
            InitializeComponent();
        }

        internal void buttonOkEdit_Click(object sender, EventArgs e)
        {
            buttonOkClicked = true;
        }

        public DataGridView GetDataGridViewRowEdit()
        {
            return this.dataGridViewRowEdit;
        }

        public Button GetButtonOkEdit()
        {
            return this.buttonOkEdit;
        }
    }
}
