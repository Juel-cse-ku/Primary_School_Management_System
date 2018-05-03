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
    public partial class Login : Form
    {
        public string TeacherID;
        int id;
        string connectionString = @"server=localhost;user id=root;database=primaryschoolmanagement";
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            
            string username;
            string password;
            int count=0;
            string login = "select TeacherID,Username,Password from login";
            MySqlCommand cmd = new MySqlCommand(login, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
               
                username = reader["Username"].ToString();
                password = reader["Password"].ToString();

                if(tb_username.Text==username && tb_password.Text==password)
                { 
                    TeacherID = reader["TeacherID"].ToString();
                    id = int.Parse(TeacherID);
                    count++;
                }
                
            }
            con.Close();

            con.Open();
            string teacherRole;
            string queryTeacherRole = "select Role from teacher where teacher.ID='" + id + "'";
            MySqlCommand cmd1 = new MySqlCommand(queryTeacherRole, con);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Read();
            teacherRole = reader1["Role"].ToString();

            GlobalVariableClass.variable_role = teacherRole;
            //MessageBox.Show(teacherRole);
            /*while (reader1.Read())
            {
                teacherRole = reader["Role"].ToString();
              //  i1 = int.Parse(TeacherID);
            }*/
            con.Close();

            if(count>0)
            {
            Home home = new Home();
            
            home.Show();
            this.Hide();
            }

            else
            {
                MessageBox.Show("Invalid Login!! Try Again");
            }
            }
            
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
