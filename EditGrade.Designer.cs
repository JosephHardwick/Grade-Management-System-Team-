namespace CSC440Team
{
    partial class EditGrade
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
            button1 = new Button();
            label1 = new Label();
            StudentID = new MaskedTextBox();
            Grade = new ComboBox();
            label2 = new Label();
            mainViewButton = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(135, 94);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 11;
            button1.Text = "View Grades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 65);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 10;
            label1.Text = "Enter the Student's ID\r\n";
            // 
            // StudentID
            // 
            StudentID.Location = new Point(29, 94);
            StudentID.Mask = "000000000";
            StudentID.Name = "StudentID";
            StudentID.Size = new Size(100, 23);
            StudentID.TabIndex = 9;
            // 
            // Grade
            // 
            Grade.FormattingEnabled = true;
            Grade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            Grade.Location = new Point(29, 170);
            Grade.Margin = new Padding(3, 2, 3, 2);
            Grade.Name = "Grade";
            Grade.Size = new Size(133, 23);
            Grade.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 141);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 18;
            label2.Text = "Enter the New Grade";
            // 
            // mainViewButton
            // 
            mainViewButton.Location = new Point(29, 397);
            mainViewButton.Name = "mainViewButton";
            mainViewButton.Size = new Size(75, 41);
            mainViewButton.TabIndex = 19;
            mainViewButton.Text = "Back to Main View";
            mainViewButton.UseVisualStyleBackColor = true;
            mainViewButton.Click += mainViewButton_Click;
            // 
            // EditGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainViewButton);
            Controls.Add(label2);
            Controls.Add(Grade);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(StudentID);
            Name = "EditGrade";
            Text = "EditGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private MaskedTextBox StudentID;
        private ComboBox Grade;
        private Label label2;
        private Button mainViewButton;
    }
}