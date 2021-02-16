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
    public partial class FormCartConfirm : Form
    {
        UserModel user;
        CartModel cart;
        public FormCartConfirm(UserModel u)
        {
            user = u;
            cart = FarmacyManager.Instance.returnCart(user);
            InitializeComponent();
            LoadToDataGridView();

        }

        public void LoadToDataGridView()
        {
            dgvCart.Rows.Clear();

            double sum = 0;
            double count = 0;
            foreach (var v in cart.DrugList)
            {
                double rowSum = v.Price * v.Quantity;
                int index = dgvCart.Rows.Add(new DataGridViewRow());
                dgvCart.Rows[index].Cells[0].Value = v.ProductCode;
                dgvCart.Rows[index].Cells[1].Value = v.Name;
                dgvCart.Rows[index].Cells[2].Value = v.Quantity;
                dgvCart.Rows[index].Cells[3].Value = v.Price;
                dgvCart.Rows[index].Cells[4].Value = rowSum;
                dgvCart.ClearSelection();
                count += v.Quantity;
                sum += rowSum;
            }

            lblTotalPrice.Text = "Price: " + sum.ToString();
            lblTotalQuantity.Text = "Quantity: " + count.ToString();

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            PaymentModel payment = new PaymentModel
            {
                Currency = "EUR",
                Method = "Visa",
                TransactionId = "12124124124"
            };
            FarmacyManager.Instance.confirmCart(user, cart, tbNotes.Text, payment);
            this.Close();
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            foreach (var v in cart.DrugList)
                FarmacyManager.Instance.updateQuantity(v.ProductCode, -v.Quantity);
            FarmacyManager.Instance.deleteCart(cart.Id);
            this.Close();
        }
    }
}
