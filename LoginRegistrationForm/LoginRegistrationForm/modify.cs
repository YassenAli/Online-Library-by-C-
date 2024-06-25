using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace LoginRegistrationForm
{
    public partial class Modify : Form
    {
        private Button exit;
        private Button update;
        private TextBox categoryText;
        private Label label4;
        private TextBox pubText;
        private Label label3;
        private TextBox titleText;
        private Label label2;
        private Button delete;
        private ComboBox bookTitle;
        private Button back;
        private Label label1;


        string chosenBook;
        int adminID = 0;
        public Modify(int id)
        {
            InitializeComponent();
            refresh();
            adminID = id;
        }

        private void refresh()
        {
            bookTitle.Items.Clear();
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string bookNamesQuery = "select title from book";
            SqlCommand bookNamesCmd = new SqlCommand(bookNamesQuery, con);
            SqlDataReader reader = bookNamesCmd.ExecuteReader();
            while (reader.Read())
            {
                bookTitle.Items.Add(reader[0].ToString());
            }
            reader.Close();
            con.Close();
        }

        private void clear()
        {
            bookTitle.Text = "";
            titleText.Text = "";
            pubText.Text = "";
            categoryText.Text = "";
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.categoryText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pubText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.bookTitle = new System.Windows.Forms.ComboBox();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome!!";
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(423, 246);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 20;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(14, 246);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 17;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // categoryText
            // 
            this.categoryText.Location = new System.Drawing.Point(222, 165);
            this.categoryText.Name = "categoryText";
            this.categoryText.Size = new System.Drawing.Size(100, 22);
            this.categoryText.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Category:";
            // 
            // pubText
            // 
            this.pubText.Location = new System.Drawing.Point(368, 107);
            this.pubText.Name = "pubText";
            this.pubText.Size = new System.Drawing.Size(130, 22);
            this.pubText.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Publication Year:";
            // 
            // titleText
            // 
            this.titleText.Location = new System.Drawing.Point(54, 107);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(134, 22);
            this.titleText.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Title:";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(154, 246);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 21;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.button1_Click);
            // 
            // bookTitle
            // 
            this.bookTitle.AllowDrop = true;
            this.bookTitle.FormattingEnabled = true;
            this.bookTitle.Location = new System.Drawing.Point(154, 49);
            this.bookTitle.Name = "bookTitle";
            this.bookTitle.Size = new System.Drawing.Size(233, 24);
            this.bookTitle.TabIndex = 22;
            this.bookTitle.SelectedIndexChanged += new System.EventHandler(this.bookTitle_SelectedIndexChanged);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(300, 246);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 23;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Modify
            // 
            this.ClientSize = new System.Drawing.Size(537, 300);
            this.Controls.Add(this.back);
            this.Controls.Add(this.bookTitle);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.update);
            this.Controls.Add(this.categoryText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pubText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modify";
            this.Load += new System.EventHandler(this.Modify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // for delete
        private void button1_Click(object sender, EventArgs e)
        {
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();

            int bookId = 0;
            string bookIdQuery = "select isbn from book where title = '" + chosenBook + "'";
            SqlCommand idCmd = new SqlCommand(bookIdQuery, con);
            SqlDataReader reader = idCmd.ExecuteReader();
            while (reader.Read())
            {
                bookId = (int)reader[0];
            }
            reader.Close();

            String deleteData = "delete from book where title = '" + chosenBook + "'";
            SqlCommand command = new SqlCommand(deleteData, con);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this book?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                string deleteWrittenBy = "delete from write_by where isbn = '" + bookId + "'";
                SqlCommand deleteWrittenByCmd = new SqlCommand(deleteWrittenBy, con);
                deleteWrittenByCmd.ExecuteNonQuery();
                command.ExecuteNonQuery();
                clear();
                refresh();
                MessageBox.Show("The book has been deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();

            String updateData = "update BOOK set title = @title, publicationyear = @pubyear, category = @category where title = '" + chosenBook + "'";
            using (SqlCommand command = new SqlCommand(updateData, con))
            { 
                command.Parameters.AddWithValue("@title", titleText.Text.ToString());
                command.Parameters.AddWithValue("@pubyear", pubText.Text.ToString());
                command.Parameters.AddWithValue("@category", categoryText.Text.ToString());
                command.ExecuteNonQuery();
                chosenBook = titleText.Text.ToString();
                refresh();
                bookTitle.Text = chosenBook;
            }

            MessageBox.Show("The book has been updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();

            chosenBook = bookTitle.Text.ToString();
            string getDetailsQuery = "select publicationyear, category from book where title = '" + chosenBook + "'";
            SqlCommand getDetailsCmd = new SqlCommand(getDetailsQuery, con);
            SqlDataReader reader = getDetailsCmd.ExecuteReader();
            while (reader.Read())
            {
                titleText.Text = chosenBook;
                DateTime date = (DateTime)reader[0];
                pubText.Text = date.ToString("yyyy");
                categoryText.Text = reader.GetString(1);
            }
            reader.Close();

            con.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Main main = new Main(adminID);
            main.Show();
            this.Hide();
        }

        private void Modify_Load(object sender, EventArgs e)
        {

        }
    }
}
