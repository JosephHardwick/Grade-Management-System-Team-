namespace CSC440Team
{
    partial class EditWindow
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
            Grade = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // Grade
            // 
            Grade.DropDownStyle = ComboBoxStyle.DropDownList;
            Grade.FormattingEnabled = true;
            Grade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            Grade.Location = new Point(50, 77);
            Grade.Name = "Grade";
            Grade.Size = new Size(151, 28);
            Grade.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 41);
            label1.Name = "label1";
            label1.Size = new Size(210, 20);
            label1.TabIndex = 18;
            label1.Text = "Please Choose The New Grade";
            // 
            // button1
            // 
            button1.Location = new Point(50, 138);
            button1.Name = "button1";
            button1.Size = new Size(151, 29);
            button1.TabIndex = 19;
            button1.Text = "Update Grade";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EditWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 211);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(Grade);
            Name = "EditWindow";
            Text = "EditWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Grade;
        private Label label1;
        private Button button1;
    }
}