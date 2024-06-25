using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;

namespace LoginRegistrationForm
{
    public partial class showData : Form
    {
        int adminID = 0;
        string bookName;

        public showData(int id)
        {
            InitializeComponent();
            refresh();
            adminID = id;
            tableName.Items.Clear();
            tableName.Items.Add("ADMIN");
            tableName.Items.Add("AUTHOR");
            tableName.Items.Add("BOOK");
            tableName.Items.Add("STUDENT");
            tableName.Items.Add("UserDetails");
            tableName.Items.Add("WRITE_BY");
            tableName.Items.Add("BOOK, AUTHOR");
            tableName.Items.Add("Book statistics");
            comboBox1.Enabled = false;
            dataGridView1.Enabled = false;

            //tableName.Items.Add("BORROWED");


        }
        private void refresh()
        {
            comboBox1.Items.Clear();
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string bookNamesQuery = "select title from book";
            SqlCommand bookNamesCmd = new SqlCommand(bookNamesQuery, con);
            SqlDataReader reader = bookNamesCmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());
            }
            reader.Close();
            con.Close();
        }

        private void showData_Load(object sender, EventArgs e)
        {

        }

        private void Show_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            if (tableName.Text == "BOOK, AUTHOR")
            {
                string bookNamesQuery1 = "select AUTHOR.NAME as Author_name  ,BOOK.TITLE as Book_Title , BOOK.CATEGORY as Book_Category from AUTHOR , BOOK, WRITE_BY  where AUTHOR.AUTHORID = WRITE_BY.AUTHORID and BOOK.ISBN = WRITE_BY.ISBN ";
                SqlCommand cmd = new SqlCommand(bookNamesQuery1, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Refresh();
                return;
            }
            else if(tableName.Text == "Book statistics")
            {
                string bookNamesQuery1 = @"SELECT 
                BOOK.TITLE, 
                BOOK.CATEGORY, 
                BOOK.PUBLICATIONYEAR, 
                COUNT(BORROWED.ISBN) AS Borrowed_Times, 
                MAX(BORROWED.RETURNDATE) AS Last_Borrowed_Date, 
                STUFF(
                    (
                        SELECT ', ' + AUTHOR.NAME
                        FROM WRITE_BY wb
                        JOIN AUTHOR ON wb.AUTHORID = AUTHOR.AUTHORID
                        WHERE wb.ISBN = BOOK.ISBN
                        FOR XML PATH(''), TYPE
                    ).value('.', 'NVARCHAR(MAX)'), 1, 2, ''
                ) AS Authors
            FROM 
                BOOK 
            LEFT JOIN WRITE_BY ON BOOK.ISBN = WRITE_BY.ISBN
            LEFT JOIN AUTHOR ON WRITE_BY.AUTHORID = AUTHOR.AUTHORID
            LEFT JOIN BORROWED ON BOOK.ISBN = BORROWED.ISBN
            where book.TITLE = '" + bookName + @"'
            GROUP BY 
                BOOK.ISBN, 
                BOOK.TITLE, 
                BOOK.CATEGORY, 
                BOOK.PUBLICATIONYEAR";

                SqlCommand cmd = new SqlCommand(bookNamesQuery1, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Refresh();
                return;
            }
            string bookNamesQuery = "select * from " + tableName.Text;
            SqlCommand cmd1 = new SqlCommand(bookNamesQuery, con);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            adapter1.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            String selectData = "SELECT UserType FROM UserDetails WHERE userid = " + adminID;
            using (SqlCommand cmd = new SqlCommand(selectData, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read(); // Move to the first retrieved row
                        string userType = reader.GetString(0); // Get user type from the second column

                        if (userType == "Admin")
                        {
                            Main mForm = new Main(adminID); // Pass user ID to constructor
                            mForm.Show();
                        }
                        else
                        {
                            userMainForm uForm = new userMainForm(adminID); // Pass user ID to constructor
                            uForm.Show();
                        }
                        this.Hide();
                    }

                }
            }
        }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }
        //list of books
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookName = comboBox1.Text;
        }

        private void tableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tableName.Text == "Book statistics")
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled=false;
            }
        }
    }
    }
