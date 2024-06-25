using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.IO;
using System.Reflection;

namespace LoginRegistrationForm
{
    public partial class Signup : Form
    {
        int id = 0;
        static string replace = @"bin\Debug";
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
        public Signup()
        {
            InitializeComponent();
        }
        private void getID()
        {
            string query = "select max(userid) from UserDetails";
            connect.Open();
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["ID"]);
            }
            connect.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (signup_email.Text == "" || signup_fname.Text == "" || signup_sname.Text == ""
            || signup_password.Text == "" || signup_confirmpassword.Text == "" || signup_checkAdmin.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (signup_password.Text != signup_confirmpassword.Text)
            {
                MessageBox.Show("password must match confirm password");
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String checkUsername = "SELECT * FROM [UserDetails] WHERE userid = @userid";
                        using (SqlCommand checkUser = new SqlCommand(checkUsername, connect))
                        {
                            checkUser.Parameters.AddWithValue("@userid", id); // Add parameter with value
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable(); ;
                            adapter.Fill(table);

                            string insertData = "INSERT INTO UserDetails (userid, email, fname, lname, password, USERTYPE) " +
                                "VALUES(@userid, @email, @fname, @lname, @password, @usertype)";


                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                cmd.Parameters.AddWithValue("@userid", id);
                                cmd.Parameters.AddWithValue("@fname", signup_userrname.Text.Trim());
                                cmd.Parameters.AddWithValue("@lname", textBox1.Text.Trim());
                                cmd.Parameters.AddWithValue("@password", signup_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@usertype", signup_checkAdmin.Text);

                                cmd.ExecuteNonQuery();

                                // Insert into specific table based on user type
                                string userType = signup_checkAdmin.Text.ToLower();
                                if (userType == "admin")
                                {
                                    string insertAdmin = "INSERT INTO Admin (UserID, Email, FName, LName, Password) VALUES (@userid, @email, @fname, @lname, @password)";
                                    using (SqlCommand cmdAdmin = new SqlCommand(insertAdmin, connect))
                                    {
                                        cmdAdmin.Parameters.AddWithValue("@userid", id);
                                        cmdAdmin.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                        cmdAdmin.Parameters.AddWithValue("@fname", signup_userrname.Text.Trim());
                                        cmdAdmin.Parameters.AddWithValue("@lname", textBox1.Text.Trim());
                                        cmdAdmin.Parameters.AddWithValue("@password", signup_password.Text.Trim());
                                        cmdAdmin.ExecuteNonQuery(); // Execute the INSERT statement
                                    }
                                }
                                else
                                {
                                    string insertStudent = "INSERT INTO Student (UserID, Email, FName, LName, Password) VALUES (@userid, @email, @fname, @lname, @password)";
                                    using (SqlCommand cmdStudent = new SqlCommand(insertStudent, connect))
                                    {
                                        cmdStudent.Parameters.AddWithValue("@userid", id);
                                        cmdStudent.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                        cmdStudent.Parameters.AddWithValue("@fname", signup_userrname.Text.Trim());
                                        cmdStudent.Parameters.AddWithValue("@lname", textBox1.Text.Trim());
                                        cmdStudent.Parameters.AddWithValue("@password", signup_password.Text.Trim());
                                        cmdStudent.ExecuteNonQuery(); // Execute the INSERT statement
                                    }
                                }

                                MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // TO SWITCH THE FORM 
                                Form1 lForm = new Form1();
                                lForm.Show();
                                this.Hide();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            if (connect.State == ConnectionState.Open)
            {
                MessageBox.Show("opened!");
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (signup_showpass.Checked)
            {
                signup_password.PasswordChar = '\0';
                signup_confirmpassword.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
                signup_confirmpassword.PasswordChar = '*';
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signup_loginhere_Click(object sender, EventArgs e)
        {
            Form1 lForm = new Form1();
            lForm.Show();
            this.Hide();
        }

        private void signup_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_userrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_confirmpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
