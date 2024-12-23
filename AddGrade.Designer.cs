﻿namespace CSC440Team
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
            mainViewButton = new Button();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft Sans Serif", 13F);
            textBox2.Location = new Point(163, 15);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(153, 71);
            textBox2.TabIndex = 0;
            textBox2.Text = "ADD GRADE";
            // 
            // Prefix
            // 
            Prefix.Location = new Point(32, 225);
            Prefix.Name = "Prefix";
            Prefix.Size = new Size(132, 27);
            Prefix.TabIndex = 2;
            // 
            // Semester
            // 
            Semester.FormattingEnabled = true;
            Semester.Items.AddRange(new object[] { "Fall", "Winter", "Spring", "Summer" });
            Semester.Location = new Point(254, 153);
            Semester.Name = "Semester";
            Semester.Size = new Size(151, 28);
            Semester.TabIndex = 4;
            // 
            // Year
            // 
            Year.Location = new Point(254, 223);
            Year.Mask = "0000";
            Year.Name = "Year";
            Year.Size = new Size(37, 27);
            Year.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 109);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 7;
            label1.Text = "StudentID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 189);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 8;
            label2.Text = "Course Prefix";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 267);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 9;
            label3.Text = "Course Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 109);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 10;
            label4.Text = "Semester";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(254, 200);
            label5.Name = "label5";
            label5.Size = new Size(37, 20);
            label5.TabIndex = 11;
            label5.Text = "Year";
            // 
            // Number
            // 
            Number.Location = new Point(32, 300);
            Number.Mask = "000L";
            Number.Name = "Number";
            Number.Size = new Size(33, 27);
            Number.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(29, 391);
            button1.Name = "button1";
            button1.Size = new Size(115, 29);
            button1.TabIndex = 14;
            button1.Text = "ADD GRADE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StudentID
            // 
            StudentID.Location = new Point(29, 153);
            StudentID.Mask = "000000000";
            StudentID.Name = "StudentID";
            StudentID.Size = new Size(66, 27);
            StudentID.TabIndex = 15;
            // 
            // Grade
            // 
            Grade.DropDownStyle = ComboBoxStyle.DropDownList;
            Grade.FormattingEnabled = true;
            Grade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            Grade.Location = new Point(254, 300);
            Grade.Name = "Grade";
            Grade.Size = new Size(151, 28);
            Grade.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(254, 267);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 17;
            label7.Text = "GRADE";
            // 
            // mainViewButton
            // 
            mainViewButton.Location = new Point(14, 16);
            mainViewButton.Margin = new Padding(3, 4, 3, 4);
            mainViewButton.Name = "mainViewButton";
            mainViewButton.Size = new Size(86, 55);
            mainViewButton.TabIndex = 20;
            mainViewButton.Text = "Back to Main View";
            mainViewButton.UseVisualStyleBackColor = true;
            mainViewButton.Click += mainViewButton_Click;
            // 
            // AddGrade
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 451);
            Controls.Add(mainViewButton);
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
        private Button mainViewButton;
    }
}