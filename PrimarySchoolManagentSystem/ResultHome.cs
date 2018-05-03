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
    public partial class ResultHome : Form
    {
        public ResultHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultInput RI = new ResultInput();
            RI.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResultShow RS = new ResultShow();
            RS.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }
    }
}
