using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Farmacy
{
    class UserModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public AddressModel Address { get; set; }
    }



}
