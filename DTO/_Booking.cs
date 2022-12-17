using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class _Booking {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("customerName")]
        public string customerName { get; set; }
        [BsonElement("sodienthoai")]
        public string sodienthoai { get; set; }
        [BsonElement("motelName")]
        public string motelName { get; set; }
        [BsonElement("motel_Id")]
        public ObjectId motel_Id { get; set; }
        [BsonElement("status")]
        public bool status { get; set; }
        [BsonElement("startDate")]
        public string startDate { get; set; }
        [BsonElement("endDate")]
        public string endDate { get; set; }
        [BsonElement("ngaytra")]
        public string ngaytra { get; set; }

        public _Booking(
            string customerName, 
            string sodienthoai,
            string motelName,
            ObjectId motel_Id, 
            bool status, string 
            startDate, 
            string endDate, 
            string ngaytra) {

            this.customerName = customerName;
            this.sodienthoai = sodienthoai;
            this.motelName = motelName;
            this.motel_Id = motel_Id;
            this.status = status;
            this.startDate = startDate;
            this.endDate = endDate;
            this.ngaytra = ngaytra;
        }
    }
}
