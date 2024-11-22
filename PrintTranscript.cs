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
using IronXL;

namespace CSC440Team
{
    public partial class PrintTranscript : Form
    {
        public PrintTranscript()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM cabj_grades_1 WHERE StudentID = @StudentID";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            Student student = new Student(int.Parse(textBox1.Text));

            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet(student.Name+"Transcript");

            sheet["A1"].Value = "Course Name";
            sheet["B1"].Value = "Course Number";
            sheet["C1"].Value = "Semester";
            sheet["D1"].Value = "Grade";
            sheet["E1"].Value = "CRN";
            sheet["F1"].Value = "Hours";
            sheet["G1"].Value = "Year";

            sheet["I3"].Value = "Student Name:";
            sheet["J3"].Value = student.Name;

            student.updateGPA();
            sheet["I4"].Value = "GPA:";
            sheet["J4"].Value = student.GPA;

            sheet["I5"].Value = "Student ID:";
            sheet["J5"].Value = student.ID;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save Transcript";
            saveFileDialog.ShowDialog();
            


            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", textBox1.Text);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    MessageBox.Show("Student has no records");
                    return;
                }
                int cnt = 2;
                while (reader.Read())
                {
                    int CRN = reader.GetInt32(reader.GetOrdinal("CRN"));
                    char grade = reader.GetChar(reader.GetOrdinal("Grade"));
                    Course course = new Course(CRN);

                    sheet[$"A{cnt}"].Value = course.Name;
                    sheet[$"B{cnt}"].Value = course.Number;
                    sheet[$"C{cnt}"].Value = course.Semester;
                    sheet[$"D{cnt}"].Value = grade.ToString();
                    sheet[$"E{cnt}"].Value = CRN;
                    sheet[$"F{cnt}"].Value = course.Hours;
                    sheet[$"G{cnt}"].Value = course.Year;
                   

                    cnt++;
                }
                
                workbook.SaveAs(saveFileDialog.FileName);
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
    }
}
