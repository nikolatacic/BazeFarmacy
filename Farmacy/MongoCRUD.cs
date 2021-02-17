using MongoDB.Driver;
using System.Collections.Generic;
using System;
using MongoDB.Bson;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Farmacy
{
    class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();

            //client.DropDatabase(database);
            
            db = client.GetDatabase(database);

            var collectionNames = db.ListCollectionNames().ToList();

            if (!collectionNames.Contains("Users"))
            {
                LoadUsersFromJSON();
            }

            if (!collectionNames.Contains("Drugs"))
            {
                LoadDrugsFromJSON();
            }

            if (!collectionNames.Contains("Carts"))
            {
                LoadCartsFromJSON();
            }

            //if (!collectionNames.Contains("Orders"))
            //{
            //    LoadOrdersFromJSON();
            //}
        }

        public void InsertDocument<T>(string table, T document)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(document);
        }

        public List<T> LoadDocuments<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadDocumentById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        public List<T> LoadDocumentByFilter<T>(string table, FilterDefinition<T> filter)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(filter).ToList();
        }

        public void UpsertDocument<T>(string table, Guid id, T document)
        {
            var collection = db.GetCollection<T>(table);

            collection.ReplaceOne(new BsonDocument("_id", id), document, new UpdateOptions { IsUpsert = true });
        }

        public void DeleteDocument<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            collection.DeleteOne(filter);
        }

        private void LoadUsersFromJSON()
        {
            List<UserModel> users;

            using (StreamReader r = new StreamReader("..\\..\\Data\\Users.json"))
            {
                string jsonUsers = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<UserModel>>(jsonUsers);
            }

            foreach (var user in users)
            {
                InsertDocument<UserModel>("Users", user);
            }
        }

        private void LoadDrugsFromJSON()
        {
            List<DrugModel> drugs;

            using (StreamReader r = new StreamReader("..\\..\\Data\\Drugs.json"))
            {
                string jsonDrugs = r.ReadToEnd();
                drugs = JsonConvert.DeserializeObject<List<DrugModel>>(jsonDrugs);
            }

            foreach (var drug in drugs)
            {
                InsertDocument<DrugModel>("Drugs", drug);
            }
        }
        private void LoadCartsFromJSON()
        {
            List<CartModel> carts;

            using (StreamReader r = new StreamReader("..\\..\\Data\\Carts.json"))
            {
                string jsonCarts = r.ReadToEnd();
                carts = JsonConvert.DeserializeObject<List<CartModel>>(jsonCarts);
            }

            foreach (var cart in carts)
            {
                InsertDocument<CartModel>("Carts", cart);
            }
        }

        private void LoadOrdersFromJSON()
        {
            List<OrderModel> orders;

            using (StreamReader r = new StreamReader("..\\..\\Data\\Orders.json"))
            {
                string jsonOrders = r.ReadToEnd();
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(jsonOrders);
            }

            foreach (var order in orders)
            {
                InsertDocument<OrderModel>("Orders", order);
            }
        }
    }
}
