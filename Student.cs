using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics.Metrics;
//using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Linq.Expressions;
using Mysqlx.Crud;
namespace CSC440Team
{
    internal class Student
    {
        private static readonly string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";


        public string Name;
        public int ID;
        public double GPA;
        

        public Student(int ID)
        {
            this.ID = ID;
            if(!exists())
            {
                //MessageBox.Show("Student does not exist.");
                return;
            }
            this.GPA = GetGPAFromDatabase(ID);
            this.Name = GetStudentNameFromDatabase(ID);
        }

        //method to check if student exists in the database
        public bool exists()
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT GPA FROM cabj_studentinfo_1 WHERE StudentID = @ID";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = query;
                //execute the command

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("executing");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();
            return false;
        }

        private double GetGPAFromDatabase(int studentID)
        {
            //updateGPA();
            double gpa = 0.0;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT GPA FROM cabj_studentinfo_1 WHERE StudentID = @ID";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = query;
                //execute the command

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", studentID);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("executing");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gpa = reader.GetDouble(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();
            Console.WriteLine("Done.");

            return gpa;
        }
        private string GetStudentNameFromDatabase(int studentID)
        {
            string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Name FROM cabj_studentinfo_1 WHERE StudentID = @ID";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //string sql = query;
                //execute the command

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", studentID);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("executing");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();
            Console.WriteLine("Done.");

            return name;
        }
        public void updateGPA()
        {
            //MessageBox.Show("updateGPA running");
        //list to hold all the courses of the student and their grade in that course
        List<(int hours, char grade)> courses = new List<(int hours, char grade)>();

        //need a course object to get the grade and hours

        //query for all the grades of the student
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
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("executing");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.HasRows)
                    {
                        return;
                    }
                    int CRN = reader.GetInt32(reader.GetOrdinal("CRN"));
                    char grade = reader.GetChar(reader.GetOrdinal("Grade"));
                    //get the hours for that course
                    Course course = new Course(CRN);//use the CRN constructor
                    int hours = course.Hours;

                    //add the course to the list
                    courses.Add((hours, grade));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();

            //now that we have all the courses and their grades we can calculate the GPA
            double totalHours = 0;
            double totalPoints = 0;
            foreach ((int hours, char grade) course in courses)
            {
                switch (course.grade)
                {
                    case 'A':
                        totalPoints += course.hours * 4.0;
                        break;
                    case 'B':
                        totalPoints += course.hours * 3.0;
                        break;
                    case 'C':
                        totalPoints += course.hours * 2.0;
                        break;
                    case 'D':
                        totalPoints += course.hours * 1.0;
                        break;
                    case 'F':
                        totalPoints += course.hours * 0;
                        break;
                }
                totalHours += course.hours;
            }
                
                if(totalPoints == 0)//dont divide by zero if student is failing all classes
                {
                    MessageBox.Show("divide by zero");
                    return;
                }
            double updatedGPA = (double)totalPoints / totalHours;
                this.GPA = updatedGPA;
                //add the updated GPA to the database
                MessageBox.Show("GPA: " + updatedGPA);
                //UPDATE cabj_studentinfo_1 SET GPA = @GPA WHERE ID = @ID
                query = "UPDATE cabj_studentinfo_1 SET GPA = @GPA WHERE StudentID = @ID";
                try
                {

                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    //string sql = query;
                    //execute the command

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", this.ID);
                    cmd.Parameters.AddWithValue("@GPA", this.GPA);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("GPA updated successfully");
                   

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
                //close the connection
                conn.Close();

            
        }

        public static int createStudent(string name)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            string query = "INSERT INTO cabj_studentinfo_1 (name, GPA) VALUES (@name, 0); SELECT LAST_INSERT_ID();";

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);


                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (int)reader.GetInt64(0);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();

            return -1;
        }
    }
}
