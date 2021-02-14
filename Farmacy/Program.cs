using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            MongoCRUD db = new MongoCRUD("Farmacy");

            db.InsertDocument<DrugModel>("Drugs", new DrugModel
            {
                ProductCode = 1,
                Name = "Brufen",
                Manufacturer = "Abbott Logistics B.V.",
                Type = "Tablets",
                Instruction = new InstructionModel
                {
                    Dose = "On every 8 hours",
                    Symptoms = new string[] { "headache" },
                    SideEffects = new string[] { "None" },
                    Warning = "",
                    Usage = "Drink with wather"
                },
                Quantity = 150,
                Price = 350
            });

            db.InsertDocument<DrugModel>("Drugs", new DrugModel
            {
                ProductCode = 2,
                Name = "Aspirin",
                Manufacturer = "Abbott Logistics B.V.",
                Type = "Tablets",
                Instruction = new InstructionModel
                {
                    Dose = "On every 12 hours",
                    Symptoms = new string[] { "headache" },
                    SideEffects = new string[] { "None" },
                    Warning = "",
                    Usage = "Drink with wather"
                },
                Quantity = 200,
                Price = 400
            });

            var drugs = db.LoadDocuments<DrugModel>("Drugs"); //select *

            foreach (var drug in drugs)
            {
                Console.Write($"{drug.Id}: {drug.ProductCode} {drug.Name} {drug.Manufacturer} {drug.Type} Quantity:{drug.Quantity} Price:{drug.Price}");

                if (drug.Instruction != null)
                {
                    Console.Write($", Dose:{drug.Instruction.Dose} Warning:{drug.Instruction.Warning} Usage:{drug.Instruction.Usage} Symptomes:{drug.Instruction.Symptoms} SideEffects:{drug.Instruction.SideEffects}");
                }

                Console.WriteLine();
            }
        }
    }
}
