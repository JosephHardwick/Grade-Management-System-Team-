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
    internal class Course
    {
        public int CRN;
        public string Name;
        public string Prefix;
        public string Number;
        public int Year;
        public string Semester;
        //we dont pass the hours because only one course is offered each semester
        public int Hours;

        public Course(string prefix, string number, int year, string semester)
        {
           
            //this.Name = name;
            this.Prefix = prefix;
            this.Number = number;
            this.Year = year;
            this.Semester = semester;
            this.CRN = getCRNFromDatabase(Prefix, Number, Year, Semester);
            this.Hours = getHoursFromDatabase(this.CRN);
        }
        //second constructor to create a course object from CRN
        public Course(int CRN)
        {
            this.CRN = CRN;
            /*
            this.Prefix = getPrefixFromDatabase(CRN);
            this.Number = getNumberFromDatabase(CRN);
            this.Year = getYearFromDatabase(CRN);
            this.Semester = getSemesterFromDatabase(CRN);
            */
            this.Hours = getHoursFromDatabase(CRN);
        }
        private int getHoursFromDatabase(int CRN)
        {
            
            if (CRN == -1)
            {
                return -1;
            }
            string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Hours FROM cabj_courseinfo_1 WHERE CRN = @CRN";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);
                
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                     return reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("hour error");
            }
            conn.Close();
            return -1;
        }
        private string getNameFromDatabase(string Prefix, string Number, int Year, string Semester) {
            string name = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT Name FROM cabj_courseinfo_1 WHERE Prefix = @Prefix AND Number = @Number AND Year = @Year AND Semester = @Semester";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Prefix", Prefix);
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@Semester", Semester);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

            return name;
        }
        
            
        private int getCRNFromDatabase(string Prefix, string Number, int Year, string Semester)
        {
            int CRN = -1;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT CRN FROM cabj_courseinfo_1 WHERE Prefix = @Prefix AND Number = @Number AND Year = @Year AND Semester = @Semester";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            MessageBox.Show("RUNNING CRN METHOD");

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Prefix", Prefix);
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@Year", Year);
                cmd.Parameters.AddWithValue("@Semester", Semester);
                //cmd.ExecuteNonQuery();
                MessageBox.Show(Prefix);
                MessageBox.Show(Number);
                MessageBox.Show(Year.ToString());
                MessageBox.Show(Semester);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    CRN = reader.GetInt32(0);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
                MessageBox.Show("ERROR");
            }
            conn.Close();
            Console.WriteLine("Done.");

            return CRN;
        }
    }
}
