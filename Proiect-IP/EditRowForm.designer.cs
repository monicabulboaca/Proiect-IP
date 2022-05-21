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
            this.dataGridViewRowEdit.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRowEdit.Name = "dataGridViewRowEdit";
            this.dataGridViewRowEdit.RowHeadersWidth = 51;
            this.dataGridViewRowEdit.RowTemplate.Height = 24;
            this.dataGridViewRowEdit.Size = new System.Drawing.Size(679, 69);
            this.dataGridViewRowEdit.TabIndex = 0;
            // 
            // buttonOkEdit
            // 
            this.buttonOkEdit.Location = new System.Drawing.Point(251, 100);
            this.buttonOkEdit.Name = "buttonOkEdit";
            this.buttonOkEdit.Size = new System.Drawing.Size(78, 32);
            this.buttonOkEdit.TabIndex = 1;
            this.buttonOkEdit.Text = "Ok";
            this.buttonOkEdit.UseVisualStyleBackColor = true;
            this.buttonOkEdit.Click += new System.EventHandler(this.buttonOkEdit_Click);
            // 
            // buttonRenuntaEdit
            // 
            this.buttonRenuntaEdit.Location = new System.Drawing.Point(380, 100);
            this.buttonRenuntaEdit.Name = "buttonRenuntaEdit";
            this.buttonRenuntaEdit.Size = new System.Drawing.Size(81, 32);
            this.buttonRenuntaEdit.TabIndex = 2;
            this.buttonRenuntaEdit.Text = "Renunță";
            this.buttonRenuntaEdit.UseVisualStyleBackColor = true;
            // 
            // EditRowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 140);
            this.Controls.Add(this.buttonRenuntaEdit);
            this.Controls.Add(this.buttonOkEdit);
            this.Controls.Add(this.dataGridViewRowEdit);
            this.Name = "EditRowForm";
            this.Text = "Editeaza rând";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRowEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRowEdit;
        private System.Windows.Forms.Button buttonOkEdit;
        private System.Windows.Forms.Button buttonRenuntaEdit;
    }
}