namespace JIRA_to_V1_Tool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_fileSelected = new System.Windows.Forms.Label();
            this.label_inputFile = new System.Windows.Forms.Label();
            this.button_convert = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox_Rules = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel Workbook|*.xls|All files|*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 105);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse for JIRA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label_fileSelected
            // 
            this.label_fileSelected.AutoSize = true;
            this.label_fileSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_fileSelected.Font = new System.Drawing.Font("Microsoft NeoGothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fileSelected.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label_fileSelected.Location = new System.Drawing.Point(117, 109);
            this.label_fileSelected.Name = "label_fileSelected";
            this.label_fileSelected.Size = new System.Drawing.Size(120, 23);
            this.label_fileSelected.TabIndex = 3;
            this.label_fileSelected.Text = "No file selected";
            // 
            // label_inputFile
            // 
            this.label_inputFile.AutoSize = true;
            this.label_inputFile.Font = new System.Drawing.Font("Microsoft NeoGothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_inputFile.Location = new System.Drawing.Point(-2, 110);
            this.label_inputFile.Name = "label_inputFile";
            this.label_inputFile.Size = new System.Drawing.Size(119, 21);
            this.label_inputFile.TabIndex = 4;
            this.label_inputFile.Text = "JIRA File Name:";
            // 
            // button_convert
            // 
            this.button_convert.Location = new System.Drawing.Point(344, 2);
            this.button_convert.Name = "button_convert";
            this.button_convert.Size = new System.Drawing.Size(104, 105);
            this.button_convert.TabIndex = 5;
            this.button_convert.Text = "CONVERT to V1";
            this.button_convert.UseVisualStyleBackColor = true;
            this.button_convert.Visible = false;
            this.button_convert.Click += new System.EventHandler(this.button_convert_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel Workbook|*.xls|All files|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // textBox_Rules
            // 
            this.textBox_Rules.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.textBox_Rules.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Rules.ForeColor = System.Drawing.Color.Black;
            this.textBox_Rules.Location = new System.Drawing.Point(102, 12);
            this.textBox_Rules.Multiline = true;
            this.textBox_Rules.Name = "textBox_Rules";
            this.textBox_Rules.ReadOnly = true;
            this.textBox_Rules.Size = new System.Drawing.Size(128, 81);
            this.textBox_Rules.TabIndex = 6;
            this.textBox_Rules.TabStop = false;
            this.textBox_Rules.Text = "JIRA \'Project\' and V1 \'Project\' must match EXACTLY";
            this.textBox_Rules.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(452, 152);
            this.Controls.Add(this.textBox_Rules);
            this.Controls.Add(this.button_convert);
            this.Controls.Add(this.label_inputFile);
            this.Controls.Add(this.label_fileSelected);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JIRA to VersionOne Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_fileSelected;
        private System.Windows.Forms.Label label_inputFile;
        private System.Windows.Forms.Button button_convert;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox_Rules;
    }
}

