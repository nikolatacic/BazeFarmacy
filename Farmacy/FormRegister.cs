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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();


            tbUsernameReg.Text = "Username";
            tbUsernameReg.ForeColor = Color.Gray;

            tbPasswordReg.Text = "Password";
            tbPasswordReg.ForeColor = Color.Gray;

            tbFirstNameReg.Text = "First name";
            tbFirstNameReg.ForeColor = Color.Gray;

            tbLastNameReg.Text = "Last name";
            tbLastNameReg.ForeColor = Color.Gray;

            tbPhoneNumberReg.Text = "Phone number";
            tbPhoneNumberReg.ForeColor = Color.Gray;

            tbStreetReg.Text = "Street";
            tbStreetReg.ForeColor = Color.Gray;

            tbNumberReg.Text = "Number";
            tbNumberReg.ForeColor = Color.Gray;

            tbZipCodeReg.Text = "Zip Code";
            tbZipCodeReg.ForeColor = Color.Gray;

            tbCityReg.Text = "City";
            tbCityReg.ForeColor = Color.Gray;

            tbCountryReg.Text = "Country";
            tbCountryReg.ForeColor = Color.Gray;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

            AddressModel address = new AddressModel{ 
                Street = tbStreetReg.Text, 
                Number = Int32.Parse(tbNumberReg.Text), 
                ZipCode = Int32.Parse(tbZipCodeReg.Text), 
                City = tbCityReg.Text, 
                Country = tbCountryReg.Text
            };

            UserModel user = new UserModel
            {
                Privileges = 1,
                Username = tbUsernameReg.Text,
                Password = tbPasswordReg.Text,
                FirstName = tbFirstNameReg.Text,
                LastName = tbLastNameReg.Text,
                PhoneNumber = tbPhoneNumberReg.Text,
                Address = address
            };


            if (FarmacyManager.Instance.register(user)) //napisi
            {

                string message = "Successfully registered! Please log in";
                string title = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    this.Hide();
                    var formLogIn = new FormLogIn();
                    formLogIn.ShowDialog();
                    this.Close();
                }

            }
            else
                lblErrorRegister.Text = "User with that username already exists";

        }

        private void tbUsernameReg_Enter(object sender, EventArgs e)
        {
            lblErrorRegister.Text = "";

            if (tbUsernameReg.Text == "Username")
            {
                tbUsernameReg.Text  =  "";
                tbUsernameReg.ForeColor = Color.Black;
            }
        }

        private void tbUsernameReg_Leave(object sender, EventArgs e)
        {
            if (tbUsernameReg.Text == "" )
            {
                tbUsernameReg.Text  =  "Username";
                tbUsernameReg.ForeColor  =  Color.Gray;
            }
        }

        private void tbPasswordReg_Enter(object sender, EventArgs e)
        {
            if (tbPasswordReg.Text == "Password")
            {
                tbPasswordReg.Text = "";
                tbPasswordReg.ForeColor = Color.Black;
            }
        }

        private void tbPasswordReg_Leave(object sender, EventArgs e)
        {
            if (tbPasswordReg.Text == "")
            {
                tbPasswordReg.Text = "Password";
                tbPasswordReg.ForeColor = Color.Gray;
            }
        }

        private void tbFirstNameReg_Enter(object sender, EventArgs e)
        {
            if (tbFirstNameReg.Text == "First name")
            {
                tbFirstNameReg.Text = "";
                tbFirstNameReg.ForeColor = Color.Black;
            }
        }

        private void tbFirstNameReg_Leave(object sender, EventArgs e)
        {
            if (tbFirstNameReg.Text == "")
            {
                tbFirstNameReg.Text = "First name";
                tbFirstNameReg.ForeColor = Color.Gray;
            }
        } 

        private void tbLastNameReg_Enter(object sender, EventArgs e)
        {
            if (tbLastNameReg.Text == "Last name")
            {
                tbLastNameReg.Text = "";
                tbLastNameReg.ForeColor = Color.Black;
            }
        }

        private void tbLastNameReg_Leave(object sender, EventArgs e)
        {
            if (tbLastNameReg.Text == "")
            {
                tbLastNameReg.Text = "Last name";
                tbLastNameReg.ForeColor = Color.Gray;
            }
        }

        private void tbPhoneNumberReg_Enter(object sender, EventArgs e)
        {
            if (tbPhoneNumberReg.Text == "Phone number")
            {
                tbPhoneNumberReg.Text = "";
                tbPhoneNumberReg.ForeColor = Color.Black;
            }
        }

        private void tbPhoneNumberReg_Leave(object sender, EventArgs e)
        {
            if (tbPhoneNumberReg.Text == "")
            {
                tbPhoneNumberReg.Text = "Phone number";
                tbPhoneNumberReg.ForeColor = Color.Gray;
            }
        }

        private void tbStreetReg_Enter(object sender, EventArgs e)
        {
            if (tbStreetReg.Text == "Street")
            {
                tbStreetReg.Text = "";
                tbStreetReg.ForeColor = Color.Black;
            }
        }

        private void tbStreetReg_Leave(object sender, EventArgs e)
        {
            if (tbStreetReg.Text == "")
            {
                tbStreetReg.Text = "Street";
                tbStreetReg.ForeColor = Color.Gray;
            }
        }

        private void tbNumberReg_Enter(object sender, EventArgs e)
        {
            if (tbNumberReg.Text == "Number")
            {
                tbNumberReg.Text = "";
                tbNumberReg.ForeColor = Color.Black;
            }
        }

        private void tbNumberReg_Leave(object sender, EventArgs e)
        {
            if (tbNumberReg.Text == "")
            {
                tbNumberReg.Text = "Number";
                tbNumberReg.ForeColor = Color.Gray;
            }
        }

        private void tbCity_Enter(object sender, EventArgs e)
        {
            if (tbCityReg.Text == "City")
            {
                tbCityReg.Text = "";
                tbCityReg.ForeColor = Color.Black;
            }
        }

        private void tbCity_Leave(object sender, EventArgs e)
        {
            if (tbCityReg.Text == "")
            {
                tbCityReg.Text = "City";
                tbCityReg.ForeColor = Color.Gray;
            }
        }

        private void tbZipCodeReg_Enter(object sender, EventArgs e)
        {
            if (tbZipCodeReg.Text == "Zip Code")
            {
                tbZipCodeReg.Text = "";
                tbZipCodeReg.ForeColor = Color.Black;
            }
        }

        private void tbZipCodeReg_Leave(object sender, EventArgs e)
        {
            if (tbZipCodeReg.Text == "")
            {
                tbZipCodeReg.Text = "Zip Code";
                tbZipCodeReg.ForeColor = Color.Gray;
            }
        }

        private void tbCountryReg_Enter(object sender, EventArgs e)
        {
            if (tbCountryReg.Text == "Country")
            {
                tbCountryReg.Text = "";
                tbCountryReg.ForeColor = Color.Black;
            }
        }

        private void tbCountryReg_Leave(object sender, EventArgs e)
        {
            if (tbCountryReg.Text == "")
            {
                tbCountryReg.Text = "Country";
                tbCountryReg.ForeColor = Color.Gray;
            }
        }
    }
}
