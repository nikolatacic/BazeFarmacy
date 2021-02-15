using MongoDB.Driver;
using System.Collections.Generic;
using System;
using MongoDB.Bson;
using System.Linq;

namespace Farmacy
{
    class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
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

        public void UpsertDocument<T>(string table, Guid id, T document) // ako postoji update-uje ako ne napravi novi
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
    }



}
