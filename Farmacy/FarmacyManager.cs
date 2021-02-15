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
                CartModel cart = new CartModel();
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

            if (users.Count == 0)
                return null;
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
            updateQuantity(drug.ProductCode, quantity);
            drug.Quantity = quantity;
            double total = quantity * drug.Price;
            var doc = returnCart(user);
            if (doc == null)
                doc = new CartModel(); //If cart doesnt exist, create new
            var drugForChange = doc.DrugList.Find(d => d.ProductCode == drug.ProductCode);
            if (drugForChange == null)
            {
                doc.DrugList.Add(drug);
                doc.Quantity += quantity;
            }
            else
            {
                doc.Quantity += quantity;
                drugForChange.Quantity += quantity;
            }

            doc.Total += total;
            db.UpsertDocument("Carts", doc.Id, doc);

        }
        public void updateQuantity(int prCode, int quantity)
        {
            var filter = Builders<DrugModel>.Filter.Eq("ProductCode", prCode);
            var drug = db.LoadDocumentByFilter("Drugs", filter).First();
            if (drug == null)
                return;
            if (drug.Quantity + quantity == 0)
                db.DeleteDocument<DrugModel>("Drugs", drug.Id);
            else
            {
                drug.Quantity -= quantity;
                db.UpsertDocument<DrugModel>("Drugs", drug.Id, drug);
            }
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

        public void updateOrders(OrderModel order, bool approved, bool deleted)
        {
            if (approved)
            {
                order.Shipping.CompanyName = "TestKompanija";
                order.Shipping.EstimatedTime = DateTime.Now.AddDays(7);
                if (!deleted)
                    order.Shipping.Status = "On the way";
                else
                    order.Shipping.Status = "Inactive";
                db.UpsertDocument<OrderModel>("Orders", order.Id, order);
            }
            else
            {
                foreach (var v in order.DrugsList)
                    updateQuantity(v.ProductCode, -v.Quantity);
                db.DeleteDocument<OrderModel>("Orders", order.Id);

            }
                
        }

        public void confirmCart(UserModel u, CartModel c, string notes, PaymentModel payment)
        {
            ShippingModel s = new ShippingModel
            {
                CustomerUsername = u.Username,
                Status = "Pending"
            };

            OrderModel o = new OrderModel
            {
                Notes = notes,
                OrderedOn = DateTime.Now,
                Payment = payment,
                Shipping = s,
                DrugsList = c.DrugList
            };


            db.DeleteDocument<CartModel>("Carts", c.Id);
        }

        public void upsertDrug(DrugModel drug)
        {
            db.UpsertDocument<DrugModel>("Drugs", drug.Id, drug);
        }

        public void deleteDrug(DrugModel drug)
        {
            db.DeleteDocument<DrugModel>("Drugs", drug.Id);
        }
    }
}
