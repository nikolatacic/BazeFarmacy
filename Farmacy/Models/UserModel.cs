using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Farmacy
{
    public class UserModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public AddressModel Address { get; set; }
    }



}
