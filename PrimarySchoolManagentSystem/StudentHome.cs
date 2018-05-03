using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimarySchoolManagentSystem
{
    public partial class StudentHome : Form
    {
        public StudentHome()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentProfile SP = new StudentProfile();
            SP.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInput SI = new StudentInput();
            SI.Show();
        }
    }
}
