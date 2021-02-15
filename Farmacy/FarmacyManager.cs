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
                CartModel cart = new CartModel { Quantity = 0, Status = "Not confirmed", Total = 0 };
                db.InsertDocument<CartModel>("Carts", cart);
                user.CartId = cart.Id;
                db.InsertDocument<UserModel>("Users", user);
            }

            return !users.Any();
        }

        public UserModel logIn(string username, string password)
        {
            var filter = Builders<UserModel>.Filter.Eq("Username", username) & Builders<UserModel>.Filter.Eq("Password", password);

            var users = db.LoadDocumentByFilter("Users", filter);

            return users.First();
        }

        public List<DrugModel> searchDrugs(FilterDefinition<DrugModel> filter)
        {
            return db.LoadDocumentByFilter("Drugs", filter);
        }
        public CartModel returnCart(UserModel user)
        {
            return db.LoadDocumentById<CartModel>("Carts", user.CartId);
        }
        public void addToCart(UserModel user, DrugModel drug, int quantity)
        {
            updateQuantity(drug, quantity);
            drug.Quantity = quantity;
            double total = quantity * drug.Price;
            var doc = returnCart(user);
            var drugForChange = doc.DrugList.Find(d => d.ProductCode == drug.ProductCode);
            if (drugForChange == null) {
                doc.DrugList.Add(drug);
                doc.Quantity += quantity;
            }
            else
                drugForChange.Quantity += quantity;

            doc.Total += total;
            db.UpsertDocument("Carts", doc.Id, doc);

        }
        public void updateQuantity(DrugModel drug, int quantity)
        {
            drug.Quantity -= quantity;
            db.UpsertDocument<DrugModel>("Drugs", drug.Id, drug);
        }

        public List<OrderModel> getOrders(string type, string username = null)
        {
            var filter = Builders<OrderModel>.Filter.Empty;
            if (type.Equals("Pending"))
                filter &= Builders<OrderModel>.Filter.Eq("Shipping.Status", "Pending");
            else if (type.Equals("MyOrders"))
                filter &= Builders<OrderModel>.Filter.Eq("Shipping.CustomerUsername", username);

            return db.LoadDocumentByFilter("Orders", filter);
        }

        //updateOrders. klijent da potvrdi kart
        //order treba da se popuni posle carta
        public void updateOrders(OrderModel order, bool approved)
        {
            if (approved)
            { //change status i popuniti podatke
                order.Shipping.CompanyName = "TestKompanija";
                order.Shipping.EstimatedTime = DateTime.Now.AddDays(7);
                order.Shipping.Status = "Active";
                db.UpsertDocument<OrderModel>("Orders", order.Id, order);
            }
            else
            {
                var filter = Builders<UserModel>.Filter.Eq("Username", order.Shipping.CustomerUsername);

                var users = db.LoadDocumentByFilter("Users", filter);
                db.DeleteDocument<OrderModel>("Orders", order.Id);
            }
                
        }
    }
}
