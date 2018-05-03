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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffManagement SM = new StaffManagement();
            SM.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentProfile sp = new StudentProfile();
            sp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResultHome RH = new ResultHome();
            RH.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Hide();

        }

        private void Home_Load(object sender, EventArgs e)
        {
            if(GlobalVariableClass.variable_role!="Head Master")
            {
                button1.Hide();
            }
        }
    }
}
