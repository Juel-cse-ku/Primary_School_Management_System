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
    public partial class StaffManagement : Form
    {
        

        static string connectionString = @"server=localhost;user id=root;database=primaryschoolmanagement";

        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();

        public StaffManagement()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 8;
           // dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].Name = "Full Name";
            dataGridView1.Columns[1].Name = "Address";
            dataGridView1.Columns[2].Name = "Phone Number";
            dataGridView1.Columns[3].Name = "Email";
            dataGridView1.Columns[4].Name = "Role";
            dataGridView1.Columns[5].Name = "DOB";
            dataGridView1.Columns[6].Name = "Sex";
            dataGridView1.Columns[7].Name = "Job Starting Year";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

        }
        
        //insert into db
       /* private void add(string full_name,string address,string phone_number,string email,string role,string dob,string sex,string jsy)
        {
            string sql = "INSERT INTO teacher(Full_Name,Address,Phone_Number,Email,Role,DOB,Sex,Job_Starting_Year) VALUES(@FULL_NAME, @ADDRESS, @PHONE_NUMBER, @EMAIL, @ROLE, @DOB, @SEX, @JOB_STARTING_YEAR)";
            cmd = new MySqlCommand(sql,con);

            //add parameters

            cmd.Parameters.AddWithValue("@PFUll_NAME", full_name);
            cmd.Parameters.AddWithValue("@PADDRESS", address);
            cmd.Parameters.AddWithValue("@PPHONE_NUMBER", phone_number);
            cmd.Parameters.AddWithValue("@PEMAIL", email);
            cmd.Parameters.AddWithValue("@PROLE", role);
            cmd.Parameters.AddWithValue("@PDOB", dob);
            cmd.Parameters.AddWithValue("@PSEX", sex);
            cmd.Parameters.AddWithValue("@PJOB_STARTING_YEAR", jsy);
            //open con and exec insert
            try
            {
                con.Open();
                if(cmd.ExecuteNonQuery()>0)
                {
                    clearText();
                    MessageBox.Show("Successfully Inserted");
                }
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }*/

        //adding to dgview
       private void populate(String full_name,string address,string phone_number,string email,string role,string dob,string sex,string jsy)
        {
            dataGridView1.Rows.Add(full_name,address,phone_number,email,role,dob,sex,jsy);
        }
       //retrieving data
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {      
                string teacherData="";
                if (comboBox1.SelectedItem == "Head Master")
                {
                    teacherData = "select ID,Full_Name,Address,Phone_Number,Email,Role,DOB,Sex,Job_Starting_Year  from teacher where Role='Head Master'";
                    
                }
                else if (comboBox1.SelectedItem == "Senior Teachers")
                {
                    teacherData = "select ID,Full_Name,Address,Phone_Number,Email,Role,DOB,Sex,Job_Starting_Year  from teacher where Role='Senior Teacher'";
                }
                else if (comboBox1.SelectedItem == "Assistant Teachers")
                {
                    teacherData = "select ID,Full_Name,Address,Phone_Number,Email,Role,DOB,Sex,Job_Starting_Year  from teacher where Role='Assistant Teacher'";
                }
                else if (comboBox1.SelectedItem == "All Teachers")
                {
                    teacherData = "select ID,Full_Name,Address,Phone_Number,Email,Role,DOB,Sex,Job_Starting_Year  from teacher";
                }
                dataGridView1.Rows.Clear();
                cmd = new MySqlCommand(teacherData,con);
            try
            {
                con.Open();

                adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);

                foreach(DataRow row in dt.Rows)
                {
                    populate(row[1].ToString(),row[2].ToString(),row[3].ToString(),row[4].ToString(),row[5].ToString(),row[6].ToString(),row[7].ToString(),row[8].ToString());
                }

                con.Close();
                //clear dt
                dt.Rows.Clear();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Source);
            }
            
            
        }

        //updating

        public bool update(string full_name,string address,string phone_number,string email,string role,string dob,string sex,string jsy)
        {
            //sql stmt

            string sql = "UPDATE teacher SET Full_Name='"+full_name+"',Address='"+ address +"',Phone_Number='"+ phone_number +"',Email='"+ email +"',Role='"+ role +"',DOB='"+ dob +"',Sex='"+ sex +"',Job_Starting_Year='"+ jsy +"' WHERE Full_Name='"+ full_name +"'";
            cmd = new MySqlCommand(sql,con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if(adapter.UpdateCommand.ExecuteNonQuery()>0)
                {
                    
                    MessageBox.Show("Updated");
                    clearText();
                }
                con.Close();
                return true;
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
        }
       
        //deleting
        public bool delete(string full_name)
        {
            string sql = "DELETE FROM teacher WHERE Full_Name='"+ full_name +"'";
            cmd = new MySqlCommand(sql,con);

            try
            {
                con.Open();

                adapter = new MySqlDataAdapter(cmd);

                adapter.DeleteCommand = con.CreateCommand();

                adapter.DeleteCommand.CommandText = sql;

                if(MessageBox.Show("Sure?","Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    if(cmd.ExecuteNonQuery()>0)
                    {
                        clearText();
                        MessageBox.Show("Deleted successfully");
                    }
                }

                con.Close();
                return true;

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;

            }
        }

        //clear txt
        
        private void clearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

        }
        private void StaffManagement_Load(object sender, EventArgs e)
        {
            
        }

        //update button
        private void button1_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //int id = Convert.ToInt32(selected);
            string s = selected;
            update(s, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
        }

     
        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           // int id = Convert.ToInt32(selected);
            string s = selected;

            delete(s);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
       
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        
    }
}
