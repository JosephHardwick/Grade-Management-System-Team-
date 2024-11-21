using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;



namespace CSC440Team
{
    public partial class ImportGrades : Form
    {
        public ImportGrades()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        string fn = "";
        private void Browse_Click(object sender, EventArgs e)
        {
            string file = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;
                file = openFileDialog1.SafeFileName;
                MessageBox.Show(file);
            }
            ;
            if (!IsValidFileName(file))
            {
                MessageBox.Show("Invalid file name. \n Please ensure your file is of the format [Course prefix] [Course Number] [Year] [semester].xlsx");
                return;
            }

            var workbook = WorkBook.Load(fn);
            var workSheet = workbook.WorkSheets.First();
            var cell = workSheet["A2"];
            int RC = workSheet.Rows.Count();
            int CC = workSheet.Columns.Count();
            int studentID = 0;

            MessageBox.Show(RC.ToString());

            string[] fileNameDetails = file.Split(' ');
            //MessageBox.Show("Course: " + fileNameDetails[0] + " " + fileNameDetails[1] + " " + fileNameDetails[2] + " " + fileNameDetails[3].Substring(0, fileNameDetails[3].Length - 5))
            Course course = new Course(fileNameDetails[0], fileNameDetails[1], int.Parse(fileNameDetails[2]), fileNameDetails[3].Substring(0, fileNameDetails[3].Length - 5));
            int CRN = course.CRN;
            if(CRN == -1)
            {
                MessageBox.Show("course does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(CRN.ToString());  


            for (int i = 2; i <= RC; i++)
            {
                cell = workSheet[$"B{i}"];
                studentID = int.Parse(cell.StringValue);
                Student student = new Student(studentID);
                MessageBox.Show(studentID.ToString());
                if (!student.exists())
                {
                    cell = workSheet[$"A{i}"];
                    MessageBox.Show("Student with name " + cell.StringValue + " does not exist in the database.");
                    return;
                }

                //add the grade
                string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                string query = "SELECT * FROM cabj_grades_1 WHERE StudentID = @ID AND CRN = @CRN";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);


                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", student.ID);
                    cmd.Parameters.AddWithValue("@CRN", CRN);
                    
                   // cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                      if (reader.HasRows)
                        {
                            MessageBox.Show("Student Already Has A Grade In This Course!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    
                }
                catch (Exception ex)
                {

                    //if we get here that means that we have duplicate entries (we check all other inputs before)
                   

                    MessageBox.Show("An error occurred: " + ex.Message);
                    MessageBox.Show("YURP");
                }
                conn.Close();

                
            }

            for (int i = 2; i <= RC; i++)
            {
                cell = workSheet[$"B{i}"];
                studentID = int.Parse(cell.StringValue);
                Student student = new Student(studentID);
                cell = workSheet[$"C{i}"];
                string grade = cell.StringValue.ToUpper();
                
                string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                string query = "INSERT INTO cabj_grades_1 (StudentID, CRN, Grade) VALUES (@StudentID, @CRN, @Grade)";


                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@StudentID", student.ID);
                    cmd.Parameters.AddWithValue("@CRN", CRN);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

               student.updateGPA();
            }
        }






        private bool IsValidFileName(string fileName)
        {
            string pattern1 = @"^[A-Z]{3}\s\d{3}\s\d{4}\s(Spring|Summer|Fall|Winter)\.xlsx$";
            string pattern2 = @"^[A-Z]{3}\s\d{3}[A-Z]\s\d{4}\s(Spring|Summer|Fall|Winter)\.xlsx$";

            return Regex.IsMatch(fileName, pattern1, RegexOptions.IgnoreCase) || Regex.IsMatch(fileName, pattern2, RegexOptions.IgnoreCase);
        }

        string readFile(string fn)
        {
            var workbook = WorkBook.Load(fn);
            var workSheet = workbook.WorkSheets.First();
            var cell = workSheet["A2"];
            int RC = workSheet.Rows.Count() - 1;
            int CC = workSheet.Columns.Count();
            return cell.StringValue;
        }
    }
}
