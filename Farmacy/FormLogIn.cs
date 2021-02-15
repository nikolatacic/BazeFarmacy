using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacy
{
    public partial class FormLogIn : Form
    {
        UserModel user;
        public FormLogIn()
        {
            InitializeComponent();
            user = new UserModel { Privileges = 0 };
        }

        private void openMain()
        {
            this.Hide();
            var formMain = new FormMain(user);
            formMain.ShowDialog();
            this.Close();
        }


        private void llGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openMain();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //check if username is legit
            UserModel temp = FarmacyManager.Instance.logIn(tbUsername.Text, tbPassword.Text);
            if (temp != null)
            {
                user = temp;
                openMain();
            }
            else
                lblErrorLogIn.Text = "Username or password is incorrect";
        }

        private void tbUsername_Click(object sender, EventArgs e)
        {
            lblErrorLogIn.Text = "";
        }

        private void tbPassword_Click(object sender, EventArgs e)
        {
            lblErrorLogIn.Text = "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formRegister = new FormRegister();
            formRegister.ShowDialog();
            this.Close();
        }
    }
}
