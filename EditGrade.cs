using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC440Team
{
    public partial class EditGrade : Form
    {
        public EditGrade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //compress the string in the masked text box to an int
            string compressedID = StudentID.Text.Replace(" ", "");

            //make the Grade object non-changeable until after a valid student is selected and grade is selected

            Student student = new Student(int.Parse(compressedID));
            if (!student.exists())
            {
                MessageBox.Show("Student does not exist");
            }
            
                //display all grades in selectable objects
                //if a grade is selected, display the grade with all pertinent details and allow for editing, run updateGPA() on student after confirmation



            
        }

        private void mainViewButton_Click(object sender, EventArgs e)
        {
            //close this window and open up main view
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
