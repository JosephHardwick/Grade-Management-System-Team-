using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSC440Team
{
    public partial class AddGrade : Form
    {
        public AddGrade()
        {
            InitializeComponent();
            Semester.SelectedIndex = 0;
            //Hours.SelectedIndex = 2;
            Grade.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string compressedNumber = Number.Text.Replace(" ", "");
            string compressedYear = Year.Text.Replace(" ", "");
            string compressedID = StudentID.Text.Replace(" ", "");

            string numericPart = compressedNumber.Substring(0, compressedNumber.Length);

            if (int.Parse(numericPart) < 100)
            {

                MessageBox.Show("Course Number has to be at least 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string capPrefix = Prefix.Text.ToUpper();
            Course course = new Course(capPrefix, compressedNumber, int.Parse(compressedYear), Semester.Text);
            int CRN = course.CRN;
            Student student = new Student(int.Parse(compressedID));
            //check if student exists
            if (!student.exists())
            {
                MessageBox.Show("Invalid Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check if course exists
            if (CRN == -1)//that is what we return if the course does not exist
            {
                MessageBox.Show("Course Deos Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //add the grade
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "INSERT INTO cabj_grades_1 (StudentID, CRN, Grade) VALUES (@StudentID, @CRN, @Grade)";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);


            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", compressedID);
                cmd.Parameters.AddWithValue("@CRN", CRN);
                cmd.Parameters.AddWithValue("@Grade", Grade.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Grade added successfully.");
            }
            catch (Exception ex)
            {

                //if we get here that means that we have duplicate entries (we check all other inputs before)
                MessageBox.Show("Student Already Has A Grade In This Course!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //MessageBox.Show("An error occurred: " + ex.Message);
            }
            conn.Close();
            student.updateGPA();
        }

        //function to calulate the GPA
        private void calculateGPA()
        {
            //get the students grades
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT* FROM cabj_grades_1 WHERE StudentID = @StudentID";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", StudentID.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                int total = 0;
                int count = 0;
                while (reader.Read())
                {

                    string grade = reader.GetString(reader.GetOrdinal("Grade"));
                    int crn = reader.GetInt32(reader.GetOrdinal("CRN"));
                    switch (grade)
                    {
                        case "A":
                            total += 4;
                            break;
                        case "B":
                            total += 3;
                            break;
                        case "C":
                            total += 2;
                            break;
                        case "D":
                            total += 1;
                            break;
                        case "F":
                            total += 0;
                            break;
                    }
                    count++;
                }
                double gpa = total / count;
                MessageBox.Show("GPA: " + gpa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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
