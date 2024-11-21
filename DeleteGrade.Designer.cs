namespace CSC440Team
{
    partial class DeleteGrade
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
            StudentID = new MaskedTextBox();
            label1 = new Label();
            button1 = new Button();
            mainViewButton = new Button();
            listView1 = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            button2 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // StudentID
            // 
            StudentID.Location = new Point(12, 48);
            StudentID.Mask = "000000000";
            StudentID.Name = "StudentID";
            StudentID.Size = new Size(108, 23);
            StudentID.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 1;
            label1.Text = "Enter the Student's ID\r\n";
            // 
            // button1
            // 
            button1.Location = new Point(12, 77);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 8;
            button1.Text = "View Grades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // mainViewButton
            // 
            mainViewButton.Location = new Point(12, 335);
            mainViewButton.Name = "mainViewButton";
            mainViewButton.Size = new Size(75, 41);
            mainViewButton.TabIndex = 20;
            mainViewButton.Text = "Back to Main View";
            mainViewButton.UseVisualStyleBackColor = true;
            mainViewButton.Click += mainViewButton_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader5, columnHeader6, columnHeader1, columnHeader3 });
            listView1.Location = new Point(138, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(403, 321);
            listView1.TabIndex = 21;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.DisplayIndex = 1;
            columnHeader2.Text = "Course";
            columnHeader2.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.DisplayIndex = 2;
            columnHeader5.Text = "Semester";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.DisplayIndex = 3;
            columnHeader6.Text = "Grade";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 100;
            // 
            // columnHeader1
            // 
            columnHeader1.DisplayIndex = 0;
            columnHeader1.Text = "Name";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "CRN";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 100;
            // 
            // button2
            // 
            button2.Location = new Point(429, 340);
            button2.Name = "button2";
            button2.Size = new Size(112, 23);
            button2.TabIndex = 22;
            button2.Text = "Delete Grade";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 134);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 23;
            label2.Text = "label2";
            // 
            // DeleteGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 388);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(listView1);
            Controls.Add(mainViewButton);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(StudentID);
            Name = "DeleteGrade";
            Text = "DeleteGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox StudentID;
        private Label label1;
        private Button button1;
        private Button mainViewButton;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader3;
        private Button button2;
        private Label label2;
    }
}