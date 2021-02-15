//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Farmacy
//{
//    public partial class FormCart : Form
//    {
//        public FormCart()
//        {
//            InitializeComponent();
//            LoadToDataGridView();
//        }

//        public void LoadToDataGridView() //Mozda bolje sa arg
//        {
//            dgv1.Rows.Clear();
//            foreach (var v in lista.Lista)
//            {
//                if (Conditions(v))
//                {
//                    decimal total = 0;
//                    //DataGridViewRow row = (DataGridViewRow)dgv1.Rows[0].Clone();
//                    int index = dgv1.Rows.Add(new DataGridViewRow());
//                    dgv1.Rows[index].Cells[0].Value = v.OrderID;
//                    dgv1.Rows[index].Cells[1].Value = v.OrderDate;
//                    dgv1.Rows[index].Cells[2].Value = v.Customer;
//                    dgv1.Rows[index].Cells[3].Value = v.Customer;
//                    for (int i = 0; i < v.Products.Count; i++)
//                    {
//                        //total += int.Parse(v.Quantity.ElementAt<int>(i).ToString()) * int.Parse(v.Unit_Price.ElementAt<double>(i).ToString());
//                        total += v.Products[i].Quantity * v.Products[i].UnitPrice;
//                    }
//                    total += v.FreightCharges;
//                    dgv1.Rows[index].Cells[4].Value = "$" + total.ToString();
//                    dgv1.Rows[index].Cells[5].Value = v.Status;
//                    dgv1.ClearSelection();
//                    //dgv1.Rows.Add(row);
//                }
//            }

//        }
//    }
//}
