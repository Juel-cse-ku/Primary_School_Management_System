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
    public partial class StudentProfile : Form
    {
        static string connectionString = @"server=localhost;user id=root;database=primaryschoolmanagement";

        MySqlConnection con = new MySqlConnection(connectionString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public StudentProfile()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 11;
            // dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "DOB";
            dataGridView1.Columns[2].Name = "Address";
            dataGridView1.Columns[3].Name = "Father's Name";
            dataGridView1.Columns[4].Name = "Father's Occupaation";
            dataGridView1.Columns[5].Name = "Mother's Name";
            dataGridView1.Columns[6].Name = "Mother's Occupation";
            dataGridView1.Columns[7].Name = "Current Class";
            dataGridView1.Columns[8].Name = "Admitted in Class";
            dataGridView1.Columns[9].Name = "Roll Number";
            dataGridView1.Columns[10].Name = "Archieved Year";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        //insert into db
        public bool add(string name, string dob, string address, string fathers_name, string fathers_occupation, string mothers_name, string mothers_occupation, String current_class, String admitted_in_class, String roll_number, string archieved_year)
        {
            string sql = "INSERT INTO student(Name,DOB,Address,Fathers_Name,Fathers_Occupation,Mothers_Name,Mothers_Occupation,CurrentClass,Admitted_in_Class,Roll_Number,ArchievedYear) VALUES(@NAME,@DOB,@ADDRESS,@FATHERS_NAME,@FATHERS_OCCUPATION,@MOTHERS_NAME,@MOTHERS_OCCUPATION,@CURRENTCLASS,@ADMITTED_IN_CLASS,@ROLL_NUMBER,@ARCHIEVEDYEAR)";
            cmd = new MySqlCommand(sql, con);

            //add parameters

            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@ADDRESS", address);
            cmd.Parameters.AddWithValue("@FATHERS_NAME", fathers_name);
            cmd.Parameters.AddWithValue("@FATHERS_OCCUPATION", fathers_occupation);
            cmd.Parameters.AddWithValue("@MOTHERS_NAME", mothers_name);
            cmd.Parameters.AddWithValue("@MOTHERS_OCCUPATION", mothers_occupation);
            cmd.Parameters.AddWithValue("@CURRENTCLASS", current_class);
            cmd.Parameters.AddWithValue("@ADMITTED_IN_CLASS", admitted_in_class);
            cmd.Parameters.AddWithValue("@ROLL_NUMBER", roll_number);
            cmd.Parameters.AddWithValue("@ARCHIEVEDYEAR", archieved_year);
            //open con and exec insert
            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // clearText();
                    MessageBox.Show("Successfully Inserted");
                }
                con.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
        }

        private void populate(String name, string dob, string address, string fathers_name, string fathers_occupation, string mothers_name, string mothers_occupation, String current_class, String admitted_in_class, String roll_number, string archieved_year)
        {
            dataGridView1.Rows.Add(name,dob,address,fathers_name,fathers_occupation,mothers_name, mothers_occupation, current_class, admitted_in_class, roll_number, archieved_year);
        }
        //retirving
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                string studentDataShow = "";
                //   studentDataShow = "select Name,Address,Fathers_Name,Fathers_Occupation,Mothers_Name,Mothers_Occupation,CurrentClass,Roll_Number,ArchievedYear from student";

                if (comboBox1.SelectedItem != "All Students" && comboBox1.SelectedItem != "Archived")
                {
                    studentDataShow = "select ID,Name,DOB,Address,Fathers_Name,Fathers_Occupation,Mothers_Name,Mothers_Occupation,CurrentClass,Admitted_in_Class,Roll_Number,ArchievedYear  from student where CurrentClass='" + comboBox1.SelectedItem + "'";


                }
                else if (comboBox1.SelectedItem == "All Students")
                {
                    studentDataShow = "select ID,Name,DOB,Address,Fathers_Name,Fathers_Occupation,Mothers_Name,Mothers_Occupation,CurrentClass,Admitted_in_Class,Roll_Number,ArchievedYear  from student ";
                }
                else if (comboBox1.SelectedItem == "Archived")
                {
                    studentDataShow = "select ID,Name,DOB,Address,Fathers_Name,Fathers_Occupation,Mothers_Name,Mothers_Occupation,CurrentClass,Admitted_in_Class,Roll_Number,ArchievedYear from student where !(ArchievedYear = 'not yet')";
                }

                dataGridView1.Rows.Clear();
                cmd = new MySqlCommand(studentDataShow, con);
                try
                {
                    con.Open();

                    adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        //populate(row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), Convert.ToInt32(row[8].ToString()), Convert.ToInt32(row[9].ToString()), Convert.ToInt32(row[10].ToString()), row[11].ToString());
                         populate(row[1].ToString(),row[2].ToString(),row[3].ToString(),row[4].ToString(),row[5].ToString(),row[6].ToString(),row[7].ToString(),row[8].ToString(),row[9].ToString(),row[10].ToString(),row[11].ToString());
                    }

                    con.Close();
                    //clear dt
                    dt.Rows.Clear();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Source);
                }



            }

        //updating
        public bool update(String name, string dob, string address, string fathers_name, string fathers_occupation, string mothers_name, string mothers_occupation, String current_class, String admitted_in_class, String roll_number, string archieved_year)
        {
            //sql stmt

            string sql = "UPDATE student SET Name='" + name + "',DOB='" + dob + "',Address='" + address + "',Fathers_Name='" + fathers_name + "',Fathers_Occupation='" + fathers_occupation + "',Mothers_Name='" + mothers_name + "',Mothers_Occupation='" + mothers_occupation + "',CurrentClass='" + current_class + "',Admitted_in_Class='" + admitted_in_class + "',Roll_Number='" + roll_number + "',ArchievedYear='"+ archieved_year +"' WHERE Name='" + name + "'";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {

                    MessageBox.Show("Updated");
                    clearText();
                    
                }
                
                con.Close();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;
            }
        }

        //deleting
        public bool delete(string name)
        {
            string sql = "DELETE FROM student WHERE Name='" + name + "'";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();

                adapter = new MySqlDataAdapter(cmd);

                adapter.DeleteCommand = con.CreateCommand();

                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Sure?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        clearText();
                        MessageBox.Show("Deleted successfully");
                        
                    }
                }

                con.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                return false;

            }
        }

        //clear text
        public bool clearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";


            return true;
        }

        //update button
        private void button3_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string s = selected;

            update( s, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text,textBox9.Text,textBox10.Text,textBox11.Text);
        
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
        }

        //insert button
        private void button1_Click(object sender, EventArgs e)
        {
           // int i = int.Parse(textBox8.Text);
            add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox9.Text, textBox11.Text);
        }

        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            // int id = Convert.ToInt32(selected);
            string s = selected;

            delete(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }
       
    }
}

