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
    public partial class DeleteGrade : Form
    {
        public DeleteGrade()
        {
            InitializeComponent();
            //Student student = new Student(int.Parse(StudentID.Text));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //compress the string in the masked text box to an int
            string compressedID = StudentID.Text.Replace(" ", "");

            Student student = new Student(int.Parse(compressedID));
            if (!student.exists())
            {
                MessageBox.Show("Student does not exist");
            }
            else
            {
                //display all grades in selectable objects
                //if selected and confirmed, delete the grade, run student.updateGPA()



            }

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
