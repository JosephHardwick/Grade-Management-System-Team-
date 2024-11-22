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
            button2 = new Button();
            label2 = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // StudentID
            // 
            StudentID.Location = new Point(12, 30);
            StudentID.Mask = "000000000";
            StudentID.Name = "StudentID";
            StudentID.Size = new Size(55, 23);
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
            button1.Location = new Point(253, 27);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 8;
            button1.Text = "View Grades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // mainViewButton
            // 
            mainViewButton.Location = new Point(12, 386);
            mainViewButton.Name = "mainViewButton";
            mainViewButton.Size = new Size(75, 41);
            mainViewButton.TabIndex = 20;
            mainViewButton.Text = "Back to Main View";
            mainViewButton.UseVisualStyleBackColor = true;
            mainViewButton.Click += mainViewButton_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader5, columnHeader6, columnHeader1 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 56);
            listView1.Name = "listView1";
            listView1.Size = new Size(352, 292);
            listView1.TabIndex = 21;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.DisplayIndex = 1;
            columnHeader2.Text = "Course";
            columnHeader2.Width = 88;
            // 
            // columnHeader5
            // 
            columnHeader5.DisplayIndex = 2;
            columnHeader5.Text = "Semester";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 88;
            // 
            // columnHeader6
            // 
            columnHeader6.DisplayIndex = 3;
            columnHeader6.Text = "Grade";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 88;
            // 
            // columnHeader1
            // 
            columnHeader1.DisplayIndex = 0;
            columnHeader1.Text = "Name";
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            columnHeader1.Width = 88;
            // 
            // button2
            // 
            button2.ForeColor = Color.Red;
            button2.Location = new Point(227, 386);
            button2.Name = "button2";
            button2.Size = new Size(134, 42);
            button2.TabIndex = 22;
            button2.Text = "Delete Grade";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 350);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 23;
            // 
            // button4
            // 
            button4.Location = new Point(93, 386);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(129, 41);
            button4.TabIndex = 24;
            button4.Text = "Edit Grade";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // DeleteGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 430);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(listView1);
            Controls.Add(mainViewButton);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(StudentID);
            Name = "DeleteGrade";
            Text = "GradeSelect";
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
        private Button button2;
        private Label label2;
        private Button button4;
    }
}