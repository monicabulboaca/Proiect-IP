namespace Proiect_IP
{
    partial class PreferencesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonCSV = new System.Windows.Forms.RadioButton();
            this.radioButtonXML = new System.Windows.Forms.RadioButton();
            this.radioButtonJSON = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select the default extension for saving files";
            // 
            // radioButtonCSV
            // 
            this.radioButtonCSV.AutoSize = true;
            this.radioButtonCSV.Location = new System.Drawing.Point(281, 27);
            this.radioButtonCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonCSV.Name = "radioButtonCSV";
            this.radioButtonCSV.Size = new System.Drawing.Size(49, 20);
            this.radioButtonCSV.TabIndex = 1;
            this.radioButtonCSV.TabStop = true;
            this.radioButtonCSV.Text = "csv";
            this.radioButtonCSV.UseVisualStyleBackColor = true;
            this.radioButtonCSV.Click += new System.EventHandler(this.radioButtonCSV_Click);
            // 
            // radioButtonXML
            // 
            this.radioButtonXML.AutoSize = true;
            this.radioButtonXML.Location = new System.Drawing.Point(283, 53);
            this.radioButtonXML.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonXML.Name = "radioButtonXML";
            this.radioButtonXML.Size = new System.Drawing.Size(48, 20);
            this.radioButtonXML.TabIndex = 2;
            this.radioButtonXML.TabStop = true;
            this.radioButtonXML.Text = "xml";
            this.radioButtonXML.UseVisualStyleBackColor = true;
            this.radioButtonXML.Click += new System.EventHandler(this.radioButtonXML_Click);
            // 
            // radioButtonJSON
            // 
            this.radioButtonJSON.AutoSize = true;
            this.radioButtonJSON.Location = new System.Drawing.Point(283, 79);
            this.radioButtonJSON.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonJSON.Name = "radioButtonJSON";
            this.radioButtonJSON.Size = new System.Drawing.Size(53, 20);
            this.radioButtonJSON.TabIndex = 3;
            this.radioButtonJSON.TabStop = true;
            this.radioButtonJSON.Text = "json";
            this.radioButtonJSON.UseVisualStyleBackColor = true;
            this.radioButtonJSON.Click += new System.EventHandler(this.radioButtonJSON_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonJSON);
            this.groupBox1.Controls.Add(this.radioButtonCSV);
            this.groupBox1.Controls.Add(this.radioButtonXML);
            this.groupBox1.Location = new System.Drawing.Point(36, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(383, 126);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 335);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonCSV;
        private System.Windows.Forms.RadioButton radioButtonXML;
        private System.Windows.Forms.RadioButton radioButtonJSON;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}