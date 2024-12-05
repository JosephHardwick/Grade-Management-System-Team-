using System;
using System.Diagnostics.Metrics;
//using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSC440Team
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Console.WriteLine("Hello World");
            //MessageBox.Show("Hello World");
            //creting the connection to the database
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "CREATE TABLE IF NOT EXISTS AntonJoeTest" +
             " (ID INT PRIMARY KEY AUTO_INCREMENT, " +

             " Start DATETIME NOT NULL, " +
             " End DATETIME NOT NULL, " +
             " Description VARCHAR(1500) NULL, " +
             "personID INT, " +
             " Name VARCHAR(20) NOT NULL)";
                //execute the command
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("executing");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            //close the connection
            conn.Close();
            Console.WriteLine("Done.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddGrade addGradeForm = new AddGrade();
            addGradeForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ImportGrades importGradesForm = new ImportGrades();
            importGradesForm.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteGrade deleteGradeForm = new DeleteGrade();
            deleteGradeForm.Show();
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    EditGrade editGradeForm = new EditGrade();
        //    editGradeForm.Show();
        //}


        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            PrintTranscript printTranscriptForm = new PrintTranscript();
            printTranscriptForm.Show();
        }
    }
}
