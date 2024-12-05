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

        private static readonly string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        string fn = "";
        private void Browse_Click(object sender, EventArgs e)
        {


            //gathering file data
            string filePath = "";
            string file = "";
            string fileNoEx = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                file = openFileDialog1.SafeFileName;
                fileNoEx = file.Substring(0, file.Length - 5);
                //MessageBox.Show(file);
            }

            if (!IsValidFileName(file))
            {
                MessageBox.Show("Invalid file name. \n Please ensure your file is of the format [Course prefix] [Course Number] [Year] [semester] [Credit Hours].xlsx");
                return;
            }
            
          

            //seperate file name into DB fields
            string[] fileNameDetails = fileNoEx.Split(' ');
            Course course = new Course(fileNameDetails[0], fileNameDetails[1], int.Parse(fileNameDetails[2]), fileNameDetails[3], int.Parse(fileNameDetails[4]));
            int CRN = course.CRN;
            //if course does not exist, create it
            if (CRN == -1)
            {
                CRN = Course.createCourse(fileNameDetails[0], fileNameDetails[1], fileNameDetails[2], fileNameDetails[3], int.Parse(fileNameDetails[4]));
            }

            //setup .xlsx reader
            GradeInserions(filePath, CRN);
            MessageBox.Show("Grades imported");
        }







        //regex to validate naming convention
        private bool IsValidFileName(string fileName)
        {
            string pattern1 = @"^[A-Z]{3}\s\d{3}\s\d{4}\s(Spring|Summer|Fall|Winter)\s\d\.xlsx$";
            string pattern2 = @"^[A-Z]{3}\s\d{3}[A-Z]\s\d{4}\s(Spring|Summer|Fall|Winter)\s\d\.xlsx$";

            return Regex.IsMatch(fileName, pattern1, RegexOptions.IgnoreCase) || Regex.IsMatch(fileName, pattern2, RegexOptions.IgnoreCase);
        }

        private bool IsValidFolderName(string folderName)
        {
            //regex expression to match the format “Grades [Year] [Semester]”
            string pattern = @"^Grades\s\d{4}\s(Spring|Summer|Fall|Winter)$";
            return Regex.IsMatch(folderName, pattern, RegexOptions.IgnoreCase);
        }

        private bool IsValidFileNameFromFolder(string folderName)
        {
            //regex expression to match the format “CSC 440a 3.xlsx”, “NET 395 2.xlsx”, “MAT 188 1.xlsx”
            string pattern = @"^[A-Za-z]{3}\s\d{3}[A-Za-z]?\s\d\.xlsx$";
            return Regex.IsMatch(folderName, pattern, RegexOptions.IgnoreCase);
        }


        //ensure student does not already have grade in this course 
        private bool GradeExists(int SID, int CRN)
        {
            string query = "SELECT * FROM cabj_grades_1 WHERE CRN = @CRN AND StudentID = @SID";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CRN", CRN);
                cmd.Parameters.AddWithValue("@SID", SID);


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


        private void GradeInserions(string filePath, int CRN)
        {

            IronXL.License.LicenseKey = "IRONSUITE.JOSEPHHARDWICK04.GMAIL.COM.22294-29C49DA80D-JJEIV-V5VLMKZCCM4P-CZ2IVHPSSYAR-EEY4W3JWWWJH-XXOA4PUGSQID-MR3GM4ARNUSQ-EEJVOQR6HOBD-M722E4-TDKLWRRI5RSOEA-DEPLOYMENT.TRIAL-WPI7OV.TRIAL.EXPIRES.01.JAN.2025";

            //ensure file is not open
            if (!WorkBook.TryLoad(filePath, out WorkBook workBook2))
            {
                MessageBox.Show("Excel sheet is Open, please close the file and try again.");
                return;
            }

            //init workbook and worksheet
            var workbook = WorkBook.Load(filePath);
            var workSheet = workbook.WorkSheets.First();
            var cell = workSheet["A2"];
            int RC = workSheet.Rows.Count();
            int CC = workSheet.Columns.Count();
            int studentID = 0;

           


            //check that grades are valid
            for (int i = 2; i <= RC; i++)
            {
                string g = workSheet[$"C{i}"].StringValue;
                if (!(g == "A" || g == "B" || g == "C" || g == "D" || g == "F"))
                {
                    MessageBox.Show($"Invalid grade '{g}' found in row {i}. Please correct the grade and try again.");
                    return;
                }

            }


            //check that each student exists, if not add to DB
            for (int i = 2; i <= RC; i++)
            {

                //get student ID
                studentID = int.Parse(workSheet[$"B{i}"].StringValue);
                Student student = new Student(studentID);
                //if student does not exist, create them
                if (!student.exists())
                {
                    //MessageBox.Show("Creating DB entry for: " + workSheet[$"A{i}"].StringValue);
                    int newID = Student.createStudent(workSheet[$"A{i}"].StringValue);

                    //MessageBox.Show("auto inc returned" + newID.ToString());
                    workSheet[$"B{i}"].Value = newID;
                    workbook.Save();

                }

            }

            //check if student already has grade for this course

            for (int i = 2; i <= RC; i++)
            {
                //get student ID
                studentID = int.Parse(workSheet[$"B{i}"].StringValue);

                if (GradeExists(studentID, CRN))
                {
                    MessageBox.Show("Student : " + workSheet[$"A{i}"].StringValue + "already has a grade of ");
                    return;
                }

            }

            //insertion of grades
            for (int i = 2; i <= RC; i++)
            {
                string query = "INSERT INTO cabj_grades_1 (StudentID, CRN, Grade) VALUES (@SID, @CRN, @Grade)";
                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SID", workSheet[$"B{i}"].StringValue);
                    cmd.Parameters.AddWithValue("@CRN", CRN);
                    cmd.Parameters.AddWithValue("@Grade", workSheet[$"C{i}"].StringValue);

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
                //close the connection
                conn.Close();

            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reading selected folder
            string folderPath = "";
            string folderName = "";
            string fileNoEx = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                folderPath = folderBrowserDialog1.SelectedPath;
                folderName = folderPath.Substring(folderPath.LastIndexOf("\\") + 1);

                //validating folder name
                if (!IsValidFolderName(folderName))
                {
                    MessageBox.Show("Invalid folder name. \nPlease ensure that your folder name is in the format: Grades [Year] [Semester] ");
                    return;
                }
            }
           // MessageBox.Show(folderPath);
            //MessageBox.Show(folderName);

            //parsing filepaths, names, and raw names for later validation
            string[] filePaths = Directory.GetFiles(folderPath, "*.xlsx");
            string[] fileNames = Directory.GetFiles(folderPath, "*.xlsx");
            string[] fileNamesNoEx = Directory.GetFiles(folderPath, "*.xlsx");

            //creating file names array
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = fileNames[i].Substring(fileNames[i].LastIndexOf("\\") + 1);
                //MessageBox.Show(fileNames[i]);
            }

            //creating fileNames array without extension
            for (int i = 0; i < fileNamesNoEx.Length; i++)
            {
                fileNamesNoEx[i] = fileNamesNoEx[i].Substring(fileNamesNoEx[i].LastIndexOf("\\") + 1);
                fileNamesNoEx[i] = fileNamesNoEx[i].Substring(0, fileNamesNoEx[i].Length - 5);


                //MessageBox.Show(fileNamesNoEx[i]);
            }



            //determining if file names are valid within folder
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (IsValidFileNameFromFolder(fileNames[i]))
                {
                    //MessageBox.Show("Valid file name " + fileNames[i]);
                }
                else
                {
                    MessageBox.Show("Either invalid file name: " + fileNames[i]);
                    return;
                }
            }


            //determining if courses exists, if not create it
            string[] folderDetails = folderName.Split(' ');

            for (int i = 0; i < fileNamesNoEx.Length; i++)
            {
                string[] fileDetails = fileNamesNoEx[i].Split(' ');

                Course course = new Course(fileDetails[0], fileDetails[1], int.Parse(folderDetails[1]), folderDetails[2]);
                int CRN = course.CRN;
                if (CRN == -1)
                {
                    //MessageBox.Show("Creating course: " + fileDetails[0] + " " + fileDetails[1]);
                    CRN = Course.createCourse(fileDetails[0], fileDetails[1], folderDetails[1], folderDetails[2], int.Parse(fileDetails[2]));
                }
                //MessageBox.Show("CRN: " + CRN);

            }
            //At this point, both file/folder name validation is done
            //also, all courses have been created
            //we can now reuse the same code from the import of a single file


            //itterating over same method used for single file import
            for (int i = 0; i < filePaths.Length; i++)
            {
                string[] fileDetails = fileNamesNoEx[i].Split(' ');

                Course course = new Course(fileDetails[0], fileDetails[1], int.Parse(folderDetails[1]), folderDetails[2]);

                int CRN = course.CRN;
                GradeInserions(filePaths[i], CRN);
            }
            MessageBox.Show("Grades imported");



        }
    }
}

