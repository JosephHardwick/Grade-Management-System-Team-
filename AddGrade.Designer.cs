namespace CSC440Team
{
    partial class AddGrade
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
            textBox2 = new TextBox();
            Prefix = new TextBox();
            Semester = new ComboBox();
            Year = new MaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            Number = new MaskedTextBox();
            button1 = new Button();
            StudentID = new MaskedTextBox();
            Grade = new ComboBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft Sans Serif", 13F);
            textBox2.Location = new Point(143, 11);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(134, 54);
            textBox2.TabIndex = 0;
            textBox2.Text = "ADD GRADE";
            // 
            // Prefix
            // 
            Prefix.Location = new Point(28, 169);
            Prefix.Margin = new Padding(3, 2, 3, 2);
            Prefix.Name = "Prefix";
            Prefix.Size = new Size(116, 23);
            Prefix.TabIndex = 2;
            // 
            // Semester
            // 
            Semester.FormattingEnabled = true;
            Semester.Items.AddRange(new object[] { "Fall", "Winter", "Spring", "Summer" });
            Semester.Location = new Point(222, 115);
            Semester.Margin = new Padding(3, 2, 3, 2);
            Semester.Name = "Semester";
            Semester.Size = new Size(133, 23);
            Semester.TabIndex = 4;
            // 
            // Year
            // 
            Year.Location = new Point(222, 167);
            Year.Margin = new Padding(3, 2, 3, 2);
            Year.Mask = "0000";
            Year.Name = "Year";
            Year.Size = new Size(33, 23);
            Year.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 82);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 7;
            label1.Text = "StudentID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 142);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 8;
            label2.Text = "Course Prefix";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 200);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 9;
            label3.Text = "Course Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(222, 82);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 10;
            label4.Text = "Semester";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(222, 150);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 11;
            label5.Text = "Year";
            // 
            // Number
            // 
            Number.Location = new Point(28, 225);
            Number.Margin = new Padding(3, 2, 3, 2);
            Number.Mask = "000L";
            Number.Name = "Number";
            Number.Size = new Size(29, 23);
            Number.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(25, 293);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(101, 22);
            button1.TabIndex = 14;
            button1.Text = "ADD GRADE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StudentID
            // 
            StudentID.Location = new Point(25, 115);
            StudentID.Margin = new Padding(3, 2, 3, 2);
            StudentID.Mask = "000000000";
            StudentID.Name = "StudentID";
            StudentID.Size = new Size(58, 23);
            StudentID.TabIndex = 15;
            // 
            // Grade
            // 
            Grade.FormattingEnabled = true;
            Grade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            Grade.Location = new Point(222, 225);
            Grade.Margin = new Padding(3, 2, 3, 2);
            Grade.Name = "Grade";
            Grade.Size = new Size(133, 23);
            Grade.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(222, 200);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 17;
            label7.Text = "GRADE";
            // 
            // AddGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 338);
            Controls.Add(label7);
            Controls.Add(Grade);
            Controls.Add(StudentID);
            Controls.Add(button1);
            Controls.Add(Number);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Year);
            Controls.Add(Semester);
            Controls.Add(Prefix);
            Controls.Add(textBox2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddGrade";
            Text = "AddGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        //private TextBox Number;
        private TextBox textBox2;
        private TextBox Prefix;
        private ComboBox Semester;
        private MaskedTextBox Year;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private MaskedTextBox Number;
        private Button button1;
        private MaskedTextBox StudentID;
        private ComboBox Grade;
        private Label label7;
    }
}