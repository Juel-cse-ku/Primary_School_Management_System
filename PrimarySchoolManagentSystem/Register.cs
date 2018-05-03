using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PrimarySchoolManagentSystem
{
    
    public partial class Register : Form
    {
        string connectionString = @"server=localhost;user id=root;database=primaryschoolmanagement";
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                string query = "INSERT INTO teacher(ID,Full_Name,Address,Phone_Number,Email,Role,DOB,Sex,Job_Starting_Year) VALUES(null,'" + tb_FullName.Text + "','" + tb_address.Text + "','" + tb_phn.Text + "','" + tb_Email.Text + "','" + cb_role.Text + "','" + tb_dob.Text + "','" + cb_sex.Text + "','" + tb_jsy.Text + "')";
                MySqlCommand cmd = new MySqlCommand(query,con);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                string teacherID;
                string queryTeacherID = "select ID from teacher where teacher.Full_Name='" + tb_FullName.Text + "'";
                MySqlCommand cmd1 = new MySqlCommand(queryTeacherID, con);
                MySqlDataReader reader = cmd1.ExecuteReader();
                while(reader.Read())
                {
                     teacherID= reader["ID"].ToString();
                     i = int.Parse(teacherID);
                }
                con.Close();

                con.Open();
                string queryReg = "INSERT INTO login(ID,Username,Password,TeacherID) VALUES (null,'" + tb_username.Text + "','" + tb_password.Text + "','" + i + "')";
                MySqlCommand cmd2 = new MySqlCommand(queryReg, con);
                cmd2.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Register Successful");
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
           
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
