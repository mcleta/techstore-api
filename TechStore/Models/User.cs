using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TechStore.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserFullName => $"{UserFirstName} {UserLastName}";
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
