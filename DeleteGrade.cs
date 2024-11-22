using MySql.Data.MySqlClient;
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
        private int studentID;
        //to make sure the user picks a grade to delete or edir
        private bool gradeSelected = false;
        public DeleteGrade()
        {
            InitializeComponent();
            //Student student = new Student(int.Parse(StudentID.Text));
            label2.Enabled = false;


        }
        private void populateList(string cName, string course, string semester, string grade, string crn)
        {


            ListViewItem item = new ListViewItem(course);
            item.SubItems.Add(semester);
            item.SubItems.Add(grade);
            item.SubItems.Add(cName);
            item.Tag = crn;
            listView1.Items.Add(item);



        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            gradeSelected = false;//reset every time the button is clicked
            // Compress the string in the masked text box to an int
            string compressedID = StudentID.Text.Replace(" ", "");
            studentID = int.Parse(compressedID);

            Student student = new Student(int.Parse(compressedID));
            if (!student.exists())
            {
                MessageBox.Show("Student does not exist");
                return;
            }

            // Display all grades in selectable objects
            // If selected and confirmed, delete the grade, run student.updateGPA()
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM cabj_grades_1 WHERE StudentID = @ID";
            MySqlConnection conn = new MySqlConnection(connStr);
            string name = "";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", int.Parse(compressedID));
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    MessageBox.Show("Student Does Not Have Any Grades To Delete.");
                    return;
                }
                while (reader.Read())
                {

                    int CRN = reader.GetInt32(reader.GetOrdinal("CRN"));
                    char grade = reader.GetChar(reader.GetOrdinal("Grade"));
                    Course course = new Course(CRN); // Use the CRN constructor
                    int hours = course.Hours;
                    string prefix = course.Prefix;
                    string number = course.Number;
                    string semester = course.Semester;
                    int year = course.Year;
                    name = student.Name;
                    string cName = course.Name; // Course name

                    populateList(cName, prefix + " " + number, semester + " " + year, grade.ToString(), CRN.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            label2.Enabled = true;
            label2.Text = "Showing Grades For: \n" + name;
            MessageBox.Show(name);
            // Close the connection
            conn.Close();
        }


        private void mainViewButton_Click(object sender, EventArgs e)
        {
            //close this window and open up main view
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                gradeSelected = true;
            }
            if (!gradeSelected)
            {
                //MessageBox.Show("Please select A Grade To Delete.");
                return;
            }

            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "DELETE FROM cabj_grades_1 WHERE StudentID = @ID AND CRN = @CRN";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                string CRN = listView1.SelectedItems[0].Tag.ToString();
                cmd.Parameters.AddWithValue("@ID", studentID);
                cmd.Parameters.AddWithValue("@CRN", CRN);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Grade Deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            button1_Click(this, EventArgs.Empty); // Call button1_Click method programmatically
            Student student = new Student(studentID);
            student.updateGPA();
            gradeSelected = false;//if the grade is deleted, the user must select a new grade
        }
        //edit button clicked
        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                gradeSelected = true;
            }
            if (!gradeSelected)
            {
                return;
            }
            //display a small window(form to update the grade)
            EditWindow editWindow = new EditWindow(studentID, int.Parse(listView1.SelectedItems[0].SubItems[4].Text));
            editWindow.ShowDialog(); // Use ShowDialog to wait until the form is closed

            listView1.Items.Clear();
            button1_Click(this, EventArgs.Empty);
            gradeSelected = false;
        }
        

    }
}
