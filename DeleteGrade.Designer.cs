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
            ButtonPanel = new Panel();
            SuspendLayout();
            // 
            // StudentID
            // 
            StudentID.Location = new Point(28, 81);
            StudentID.Mask = "000000000";
            StudentID.Name = "StudentID";
            StudentID.Size = new Size(100, 23);
            StudentID.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 52);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 1;
            label1.Text = "Enter the Student's ID\r\n";
            // 
            // button1
            // 
            button1.Location = new Point(134, 81);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 8;
            button1.Text = "View Grades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // mainViewButton
            // 
            mainViewButton.Location = new Point(28, 397);
            mainViewButton.Name = "mainViewButton";
            mainViewButton.Size = new Size(75, 41);
            mainViewButton.TabIndex = 20;
            mainViewButton.Text = "Back to Main View";
            mainViewButton.UseVisualStyleBackColor = true;
            mainViewButton.Click += mainViewButton_Click;
            // 
            // ButtonPanel
            // 
            ButtonPanel.Location = new Point(326, 52);
            ButtonPanel.Name = "ButtonPanel";
            ButtonPanel.Size = new Size(462, 386);
            ButtonPanel.TabIndex = 21;
            // 
            // DeleteGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonPanel);
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
        private Panel ButtonPanel;
    }
}