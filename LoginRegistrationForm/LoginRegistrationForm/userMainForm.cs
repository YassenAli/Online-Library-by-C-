using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegistrationForm
{
    public partial class userMainForm : Form
    {
        int userid = 0;
        public userMainForm(int id)
        {
            InitializeComponent();
            userid = id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {

        }

        private void modify_Click(object sender, EventArgs e)
        {
            updateUserDetailsForm mForm = new updateUserDetailsForm(userid);
            mForm.Show();
            this.Hide();
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userMainForm_Load(object sender, EventArgs e)
        {

        }

        private void showbooks_Click(object sender, EventArgs e)
        {
            showData sd = new showData(userid);
            sd.Show();
            this.Hide();
        }
    }
}
