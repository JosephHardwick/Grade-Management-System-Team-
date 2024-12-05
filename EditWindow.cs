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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSC440Team
{
    public partial class EditWindow : Form
    {
        private int StudentID;
        private int CRN;
        public EditWindow(int StudentID, int CRN)//to know what grade to edit
        {
            InitializeComponent();
            this.StudentID = StudentID;
            this.CRN = CRN;

        }

        //updating grade in DB with new grade
        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "UPDATE cabj_grades_1 SET Grade = @Grade WHERE StudentID = @ID AND CRN = @CRN";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", StudentID);
                cmd.Parameters.AddWithValue("@CRN", CRN);
                cmd.Parameters.AddWithValue("@Grade", Grade.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Grade Updated.");
                Student student = new Student(StudentID);
                student.updateGPA();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

            
            
           
        }
    }
}
