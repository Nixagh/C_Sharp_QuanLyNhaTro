using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DTO {
    public class _User {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("username")]
        public string username { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("phoneNumber")]
        public string phoneNumber { get; set; }
        [BsonElement("hostId")]
        public string hostId { get; set; }
        [BsonElement("Role")]
        public string Role { get; set; }

        public _User(string username, string password, 
                        string name, string email, 
                        string phoneNumber, string hostId, string role) {
            this.username = username;
            this.password = password;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.hostId = hostId;
            Role = role;
        }

        public _User() { }
    }

}
