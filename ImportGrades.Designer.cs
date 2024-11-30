namespace CSC440Team
{
    partial class ImportGrades
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
            openFileDialog1 = new OpenFileDialog();
            importFile = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // importFile
            // 
            importFile.Location = new Point(12, 63);
            importFile.Name = "importFile";
            importFile.Size = new Size(170, 23);
            importFile.TabIndex = 0;
            importFile.Text = "Import File";
            importFile.UseVisualStyleBackColor = true;
            importFile.Click += Browse_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 92);
            button1.Name = "button1";
            button1.Size = new Size(170, 23);
            button1.TabIndex = 1;
            button1.Text = "Import Folder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 26);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 2;
            label1.Text = "Import Grades";
            // 
            // ImportGrades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(200, 127);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(importFile);
            Name = "ImportGrades";
            Text = "ImportGrades";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button importFile;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Label label1;
    }
}