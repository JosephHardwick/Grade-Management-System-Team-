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


            //display all grades in selectable objects
            //if selected and confirmed, delete the grade, run student.updateGPA()
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT* FROM cabj_grades_1 WHERE StudentID = @ID";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = query;
                //execute the command

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", int.Parse(compressedID));
                //cmd.ExecuteNonQuery();
                //MessageBox.Show("executing");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Student Does Not Have Any Grades To Delete.");
                        return;
                    }
                    int CRN = reader.GetInt32(reader.GetOrdinal("CRN"));
                    char grade = reader.GetChar(reader.GetOrdinal("Grade"));
                    //get the hours for that course
                    Course course = new Course(CRN);//use the CRN constructor
                    int hours = course.Hours;
                    string prefix = course.Prefix;
                    string number = course.Number;
                    string semester = course.Semester;
                    int year = course.Year;
                    string name = student.Name;
                    string cName = course.Name;//course name
                    
                    int buttonSpacing = 10; // Set the vertical spacing between buttons
                    int buttonHeight = 100; // Set the height of each button

                    Button button = new Button
                    {
                        Text = name + "\n " + 
                        "Course: " + cName + "\n" +"Hours: " + hours + " " + "\n"
                        + prefix + " " + number + " " + semester +
                        " " + year + "\n " + "Grade: " + grade,
                        Location = new Point(10, 10 + (buttonHeight + buttonSpacing) * this.ButtonPanel.Controls.Count),
                        Size = new Size(200, buttonHeight)
                    };
                    
                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();




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
