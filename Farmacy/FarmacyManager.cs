using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacy
{
    class FarmacyManager
    {
        public FarmacyManager()
        {
            MongoCRUD db = new MongoCRUD("Farmacy");
        }

        public bool logIn(string username, string password)
        {

        }
    }
}
