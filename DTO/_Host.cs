using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DTO {
    public class _Host {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("image")]
        public string image { get; set; }
        [BsonElement("address")]
        public Address address { get; set; }
        [BsonElement("phoneNumber")]
        public string phoneNumber { get; set; }
        [BsonElement("addressDetail")]
        public string addressDetail { get; set; }
        [BsonElement("facebook")]
        public string facebook { get; set; }
        [BsonElement("user_Id")]
        public ObjectId user_Id { get; set; }
        [BsonElement("isActive")]
        public bool isActive { get; set; } = false;
        [BsonElement("isPost")]
        public bool isPost { get; set; } = false;
        [BsonElement("descrption")]
        public bool descrption { get; set; } = false;

        public _Host(string name, string image, Address address, 
                    string phoneNumber, string addressDetail, string facebook, ObjectId user_Id) {
            this.name = name;
            this.image = image;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.addressDetail = addressDetail;
            this.facebook = facebook;
            this.user_Id = user_Id;
        }
    }
}
