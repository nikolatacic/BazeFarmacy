using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacy
{
    class FarmacyManager
    {
        private MongoCRUD db;
        private static FarmacyManager instance = null;
        private static readonly object padlock = new object();

        public static FarmacyManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FarmacyManager();
                    }
                    return instance;
                }
            }
        }
        public FarmacyManager()
        {
            db = new MongoCRUD("Farmacy");
        }

        public bool register(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("Usersname", user.Username);

            var users = db.LoadDocumentByFilter("Users", filter);

            if (!users.Any())
            {
                db.InsertDocument<UserModel>("Users", user);
            }

            return !users.Any();
        }

        public bool logIn(string username, string password)
        {
            var filter = Builders<UserModel>.Filter.Eq("Username", username) & Builders<UserModel>.Filter.Eq("Password", password);

            var users = db.LoadDocumentByFilter("Users", filter);

            return users.Any();
        }

        public List<DrugModel> searchDrugs(FilterDefinition<DrugModel> filter)
        { 

        }
    }
}
