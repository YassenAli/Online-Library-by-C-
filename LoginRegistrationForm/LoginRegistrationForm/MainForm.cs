using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegistrationForm 
{
    public partial class MainForm : Form
    {
        int bookId, authorId, adminID;
        public MainForm(int id)
        {
            InitializeComponent();
            adminID = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Insert_Click(object sender, EventArgs e)
        {
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string bookIdQuery = "select max(isbn) from book";
            SqlCommand bookIdCmd = new SqlCommand(bookIdQuery, con);
            SqlDataReader reader = bookIdCmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0))
                {
                    bookId = 1;
                    break;
                }
                bookId = ((int) reader[0]) + 1;
            }
            reader.Close();

            string authorIdQuery = "select max(authorid) from author";
            SqlCommand authorIdCmd = new SqlCommand(authorIdQuery, con);
            reader = authorIdCmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0))
                {
                    authorId = 1;
                    break;
                }
                authorId = ((int) reader[0]) + 1;
            }
            reader.Close();


            String insertData = "insert into BOOK(ISBN, TITLE, PUBLICATIONYEAR, CATEGORY) values(@ISBN, @Title, @publicationYear, @Category)";
            using (SqlCommand command = new SqlCommand(insertData, con))
            {
                command.Parameters.AddWithValue("@ISBN", bookId);
                command.Parameters.AddWithValue("@Title", textBox1.Text.ToString());
                command.Parameters.AddWithValue("@publicationYear", textBox2.Text.ToString());
                command.Parameters.AddWithValue("@Category", textBox3.Text.ToString());
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
            }

            String check_author = "select count(*) from author where name = '" + author_name.Text.ToString() + "'";

            SqlCommand countCommand = new SqlCommand(check_author, con);

            int numberOfAuthors = (int) countCommand.ExecuteScalar();
            if (numberOfAuthors == 0) {
                String authorInsertion = "insert into AUTHOR values(@id, @name)";
                using (SqlCommand command2 = new SqlCommand(authorInsertion, con))
                {

                    command2.Parameters.AddWithValue("@id", authorId++);
                    command2.Parameters.AddWithValue("@name", author_name.Text.ToString());
                    command2.ExecuteNonQuery();
                }

            }

            authorIdQuery = "select authorid from author where name = '" + author_name.Text.ToString() + "'";
            authorIdCmd = new SqlCommand(authorIdQuery, con);
            reader = authorIdCmd.ExecuteReader();
            int authorID = 0;
            while (reader.Read())
            {
                authorID = (int) reader[0];
            }
            reader.Close();

            String writtenBy = "insert into WRITE_BY values(@bookID, @authorID)";
            using (SqlCommand writeByCmd = new SqlCommand(writtenBy, con))
            {
                writeByCmd.Parameters.AddWithValue("@bookID", bookId);
                writeByCmd.Parameters.AddWithValue("@authorID", authorID);
                writeByCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Insertion completed", "Insert box", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void author_Click(object sender, EventArgs e)
        {

        }

        private void author_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Main main = new Main(adminID);
            main.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
