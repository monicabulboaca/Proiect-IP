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
        private Form1 mainForm = null;

        public EditRowForm(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        internal void buttonOkEdit_Click(object sender, EventArgs e)
        {
            this.mainForm.OkButtonEditRow();
            this.Close();
        }



        public DataGridView GetDataGridViewRowEdit()
        {
            return this.dataGridViewRowEdit;
        }

        public Button GetButtonOkEdit()
        {
            return this.buttonOkEdit;
        }

        private void buttonRenuntaEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
