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
            Hours.SelectedIndex = 2;
            Grade.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string compressedNumber = Number.Text.Replace(" ", "");
            string compressedYear = Year.Text.Replace(" ", "");
            string compressedID = StudentID.Text.Replace(" ", "");

            string numericPart = compressedNumber.Substring(0, compressedNumber.Length);
            /*
            if (!(int.TryParse(numericPart, out int number) && number >= 100))
            {
                // Number is greater than or equal to 100
                MessageBox.Show("The number is greater than or equal to 100.");
                return;
            }
            */
            string capPrefix = Prefix.Text.ToUpper();
            Course course = new Course(capPrefix, compressedNumber, int.Parse(compressedYear), Semester.Text);
            int CRN = course.CRN;
            Student student = new Student(int.Parse(compressedID));//we dont really need this

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
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        /*
        //function to calulate the GPA
        private void calculateGPA()
        {
            //get the students grades
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Grade FROM cabj_grades_1 WHERE StudentID = @StudentID";
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
                    string grade = reader.GetString(0);
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
        */
    }
}
