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
    public partial class FormInformation : Form
    {
        DrugModel drug;
        UserModel user;
        public FormInformation(UserModel u, DrugModel d)
        {
            InitializeComponent();
            drug = d;
            user = u;
            label1.Text = drug.Name;
            tbInfo.Text = drug.formatString();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblTotal.Text = ((double)nud.Value * drug.Price).ToString();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if ((int)nud.Value <= drug.Quantity)
            {
                //messagebox success! i onda close
                FarmacyManager.Instance.addToCart(user, drug, (int)nud.Value);
                string message = "Adding to cart is successfull!";
                string title = "Sucess";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
                lblError.Text = "There are not enough products";
        }
    }
}
