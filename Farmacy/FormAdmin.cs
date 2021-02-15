using MongoDB.Driver;
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
    public partial class FormAdmin : Form
    {
        private List<DrugModel> listOfDrugs;

        private UserModel user;

        public FormAdmin()
        {
            InitializeComponent();
            fillList();
        }

        private void fillList()
        {
            listOfDrugs = FarmacyManager.Instance.searchDrugs(Builders<DrugModel>.Filter.Empty).Distinct().ToList();

            dgvDrugList.Rows.Clear();
            foreach (var v in listOfDrugs)
            {
                int index = dgvDrugList.Rows.Add(new DataGridViewRow());
                dgvDrugList.Rows[index].Cells[0].Value = v.ProductCode;
                dgvDrugList.Rows[index].Cells[1].Value = v.Name;
                dgvDrugList.Rows[index].Cells[2].Value = v.Manufacturer;
                dgvDrugList.Rows[index].Cells[3].Value = v.Type;
                dgvDrugList.Rows[index].Cells[4].Value = v.Quantity;
                dgvDrugList.Rows[index].Cells[5].Value = v.Price;
                dgvDrugList.Rows[index].Cells[6].Value = v.Instruction.Dose;

                string symptoms = "";

                foreach (var symptom in v.Instruction.Symptoms)
                {
                    symptoms += symptom + " ";
                }

                dgvDrugList.Rows[index].Cells[7].Value = symptoms; 

                string sideEffects = "";

                foreach (var sideEffect in v.Instruction.SideEffects)
                {
                    sideEffects += sideEffect + " ";
                }

                dgvDrugList.Rows[index].Cells[8].Value = sideEffects;        
                
                dgvDrugList.Rows[index].Cells[9].Value = v.Instruction.Warning;
                dgvDrugList.Rows[index].Cells[10].Value = v.Instruction.Usage;

                dgvDrugList.ClearSelection();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DrugModel drug=new DrugModel();

            for (int i = 0; i < dgvDrugList.RowCount-1; i++)
            {
                if (i < listOfDrugs.Count)
                {
                    drug.Id = listOfDrugs[i].Id;
                }
                else
                {
                    drug.Id = new Guid();
                }

                drug.ProductCode = Convert.ToInt32(dgvDrugList.Rows[i].Cells[0].Value);
                drug.Name = dgvDrugList.Rows[i].Cells[1].Value.ToString();
                drug.Manufacturer = dgvDrugList.Rows[i].Cells[2].Value.ToString();
                drug.Type = dgvDrugList.Rows[i].Cells[3].Value.ToString();
                drug.Quantity = Convert.ToInt32(dgvDrugList.Rows[i].Cells[4].Value);
                drug.Price = Convert.ToInt32(dgvDrugList.Rows[i].Cells[5].Value);

                InstructionModel instruction = new InstructionModel();
                instruction.Dose = dgvDrugList.Rows[i].Cells[6].Value.ToString();

                string[] symptoms = dgvDrugList.Rows[i].Cells[7].Value.ToString().Split(' ');
                instruction.Symptoms = symptoms;

                string[] sideEffects = dgvDrugList.Rows[i].Cells[8].Value.ToString().Split(' ');
                instruction.SideEffects = sideEffects;


                instruction.Warning = dgvDrugList.Rows[i].Cells[9].Value.ToString();
                instruction.Usage = dgvDrugList.Rows[i].Cells[10].Value.ToString();

                drug.Instruction = instruction;

                FarmacyManager.Instance.upsertDrug(drug);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DrugModel drug = new DrugModel();

            var selectedRow = dgvDrugList.SelectedRows;

            for (int i = 0; i < selectedRow.Count; i++)
            {

                drug.Id = listOfDrugs[selectedRow[i].Index].Id;

                drug.Name = selectedRow[i].Cells[1].Value.ToString();
                drug.Manufacturer = selectedRow[i].Cells[2].Value.ToString();
                drug.Type = selectedRow[i].Cells[3].Value.ToString();
                drug.Quantity = Convert.ToInt32(selectedRow[i].Cells[4].Value);
                drug.Price = Convert.ToInt32(selectedRow[i].Cells[5].Value);

                InstructionModel instruction = new InstructionModel();
                instruction.Dose = selectedRow[i].Cells[6].Value.ToString();

                string[] symptoms = selectedRow[i].Cells[7].Value.ToString().Split(' ');
                instruction.Symptoms = symptoms;

                string[] sideEffects = selectedRow[i].Cells[8].Value.ToString().Split(' ');
                instruction.SideEffects = sideEffects;


                instruction.Warning = selectedRow[i].Cells[9].Value.ToString();
                instruction.Usage = selectedRow[i].Cells[10].Value.ToString();

                drug.Instruction = instruction;

                FarmacyManager.Instance.deleteDrug(drug);

                dgvDrugList.Rows.Clear();

                fillList();
            }
        }
    }
}
