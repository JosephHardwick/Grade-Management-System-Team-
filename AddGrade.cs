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
    public partial class AddGrade : Form
    {
        public AddGrade()
        {
            InitializeComponent();
            Semester.SelectedIndex = 0;
            Hours.SelectedIndex = 2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Number.Text);
            MessageBox.Show(Year.Text);
        }
    }
}
