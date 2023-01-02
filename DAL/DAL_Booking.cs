using DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public class DAL_Booking : BaseRepository<Booking>{
        public DAL_Booking(IMongoCollection<Booking> collection) : base(collection) {
            this.collection = collection;
        }
    }
}
