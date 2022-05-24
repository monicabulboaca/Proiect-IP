namespace Proiect_IP
{
    partial class EditRowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewRowEdit = new System.Windows.Forms.DataGridView();
            this.buttonOkEdit = new System.Windows.Forms.Button();
            this.buttonRenuntaEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRowEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRowEdit
            // 
            this.dataGridViewRowEdit.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewRowEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRowEdit.Location = new System.Drawing.Point(9, 10);
            this.dataGridViewRowEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewRowEdit.Name = "dataGridViewRowEdit";
            this.dataGridViewRowEdit.RowHeadersWidth = 51;
            this.dataGridViewRowEdit.RowTemplate.Height = 24;
            this.dataGridViewRowEdit.Size = new System.Drawing.Size(509, 56);
            this.dataGridViewRowEdit.TabIndex = 0;
            // 
            // buttonOkEdit
            // 
            this.buttonOkEdit.Location = new System.Drawing.Point(188, 81);
            this.buttonOkEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOkEdit.Name = "buttonOkEdit";
            this.buttonOkEdit.Size = new System.Drawing.Size(58, 26);
            this.buttonOkEdit.TabIndex = 1;
            this.buttonOkEdit.Text = "Ok";
            this.buttonOkEdit.UseVisualStyleBackColor = true;
            this.buttonOkEdit.Click += new System.EventHandler(this.buttonOkEdit_Click);
            // 
            // buttonRenuntaEdit
            // 
            this.buttonRenuntaEdit.Location = new System.Drawing.Point(285, 81);
            this.buttonRenuntaEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRenuntaEdit.Name = "buttonRenuntaEdit";
            this.buttonRenuntaEdit.Size = new System.Drawing.Size(61, 26);
            this.buttonRenuntaEdit.TabIndex = 2;
            this.buttonRenuntaEdit.Text = "Cancel";
            this.buttonRenuntaEdit.UseVisualStyleBackColor = true;
            this.buttonRenuntaEdit.Click += new System.EventHandler(this.buttonRenuntaEdit_Click);
            // 
            // EditRowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 114);
            this.Controls.Add(this.buttonRenuntaEdit);
            this.Controls.Add(this.buttonOkEdit);
            this.Controls.Add(this.dataGridViewRowEdit);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditRowForm";
            this.Text = "Row edit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRowEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRowEdit;
        private System.Windows.Forms.Button buttonOkEdit;
        private System.Windows.Forms.Button buttonRenuntaEdit;
    }
}