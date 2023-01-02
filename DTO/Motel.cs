using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace DTO {
    public class Motel {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("type")]
        public string type { get; set; } = "Bình Thường";
        [BsonElement("area")]
        public string area { get; set; }
        [BsonElement("price")]
        public string price { get; set; }
        [BsonElement("priceE")]
        public string priceE { get; set; }
        [BsonElement("priceW")]
        public string priceW { get; set; }
        [BsonElement("image")]
        public string image { get; set; }
        [BsonElement("hostId")]
        public ObjectId hostId { get; set; }
        [BsonElement("status")]
        public string status { get; set; } = "Trống";

        public Motel(string name, string type, string area, string price, string priceE, string priceW, string image, ObjectId hostId) {
            this.name = name;
            this.type = type;
            this.area = area;
            this.price = price;
            this.priceE = priceE;
            this.priceW = priceW;
            this.image = image;
            this.hostId = hostId;
        }
        public Motel() { }
    }
}
