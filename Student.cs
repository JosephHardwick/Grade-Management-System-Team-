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
namespace CSC440Team
{
    internal class Student
    {
        public string Name;
        public int ID;
        public int GPA;

        public Student(int ID)
        {
            this.ID = ID;
            this.GPA = GetGPAFromDatabase(ID);
            this.Name = GetStudentNameFromDatabase(ID);
        }

        private int GetGPAFromDatabase(int studentID)
        {
            int gpa = 0;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT GPA FROM cabj_studentinfo_1 WHERE ID = @ID";

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
                    gpa = reader.GetInt32(0);
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
            string query = "SELECT Name FROM cabj_studentinfo_1 WHERE ID = @ID";

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
    }
}
