using Proiect_IP.DatabaseParser;
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private Button quitEditsButton;
        private Button saveFileButton;
        private Button openFileButton;
        private DataGridView dataGridTable;
        private IDatabaseModeler _modeler;

        public Form1()
        {
            InitializeComponent();
            this.dataGridTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTable_CellClick);
            this.dataGridTable.AllowUserToDeleteRows = false;

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {

        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridTable_CellClick(Object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridTable.ColumnCount - 1) // edit button
                {
                    this.dataGridTable.ReadOnly = false;
                    EditRowForm editRowForm = new EditRowForm();
                    SetupDataGridViewRowEdit(editRowForm, e);
                    editRowForm.ShowDialog();
                    if(editRowForm.buttonOkClicked)
                    {
                        string[] row = new string[records[e.RowIndex].Data.Count];

                        for (int j = 0; j < records[e.RowIndex].Data.Count; j++)
                        {
                            row[j] = (string)editRowForm.GetDataGridViewRowEdit().Rows[0].Cells[j].Value;
                            this.dataGridTable.Rows[e.RowIndex].Cells[j].Value = row[j];
                        }
                        editRowForm.Close();
                    }
                }
                else if (e.ColumnIndex == dataGridTable.ColumnCount - 2) // delete button
                {
                    string message = "Sunteti sigur ca vreti sa stergeti randul?";
                    string title = "Stergere rand";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.dataGridTable.AllowUserToDeleteRows = true;
                        this.dataGridTable.Rows[e.RowIndex].Selected = true;
                        this.dataGridTable.Rows.RemoveAt(e.RowIndex);
                    }

                }
                this.dataGridTable.AllowUserToDeleteRows = false;
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
            form.GetDataGridViewRowEdit().SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitEditsButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.dataGridTable = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "Help";
            // 
            // quitEditsButton
            // 
            this.quitEditsButton.Location = new System.Drawing.Point(534, 519);
            this.quitEditsButton.Name = "quitEditsButton";
            this.quitEditsButton.Size = new System.Drawing.Size(94, 46);
            this.quitEditsButton.TabIndex = 10;
            this.quitEditsButton.Text = "Quit";
            this.quitEditsButton.UseVisualStyleBackColor = true;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(401, 521);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(94, 42);
            this.saveFileButton.TabIndex = 9;
            this.saveFileButton.Text = "Save as";
            this.saveFileButton.UseVisualStyleBackColor = true;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(269, 522);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(94, 43);
            this.openFileButton.TabIndex = 8;
            this.openFileButton.Text = "Load";
            this.openFileButton.UseVisualStyleBackColor = true;
            // 
            // dataGridTable
            // 
            this.dataGridTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTable.Location = new System.Drawing.Point(12, 41);
            this.dataGridTable.Name = "dataGridTable";
            this.dataGridTable.RowHeadersWidth = 51;
            this.dataGridTable.RowTemplate.Height = 24;
            this.dataGridTable.Size = new System.Drawing.Size(919, 472);
            this.dataGridTable.TabIndex = 7;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(943, 591);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.quitEditsButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.dataGridTable);
            this.Name = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
