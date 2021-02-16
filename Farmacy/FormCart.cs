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
    public partial class FormCart : Form
    {
        List<OrderModel> list;
        UserModel user;
        public FormCart(UserModel u)
        {
            InitializeComponent();
            user = u;
            cb.Text = "My orders";
            if (user.Privileges > 1)
                cb.Visible = true;
            else
                cb.Visible = false;


            LoadToDataGridView();
        }

        public void LoadToDataGridView() //Mozda bolje sa arg
        {
            dgvCart.Rows.Clear();

            if (user.Privileges > 1 && cb.Text.Equals("Pending orders"))
            {
                list = FarmacyManager.Instance.getOrders("Pending");
            }
            else
            {
                list = FarmacyManager.Instance.getOrders("MyOrders", user.Username);
            }


            foreach (var v in list)
            {
                int index = dgvCart.Rows.Add(new DataGridViewRow());
                dgvCart.Rows[index].Cells[0].Value = v.Shipping.CustomerUsername;
                dgvCart.Rows[index].Cells[1].Value = v.Shipping.Status;
                dgvCart.Rows[index].Cells[2].Value = v.Notes;
                dgvCart.Rows[index].Cells[3].Value = v.OrderedOn;
                dgvCart.Rows[index].Cells[4].Value = v.Payment.formatString();
                dgvCart.Rows[index].Cells[5].Value = v.Shipping.formatString();
                dgvCart.ClearSelection();
            }

        }

        private void cb_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadToDataGridView();
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(user.Privileges > 1 && cb.Text.Equals("Pending orders"))
            {
                string message = "Do you want to approve this order?";
                string title = "Approve order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    FarmacyManager.Instance.updateOrders(list[e.RowIndex], true, false);
                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    FarmacyManager.Instance.updateOrders(list[e.RowIndex], true, true);
                    this.Close();
                }
            }
        }
    }
}
