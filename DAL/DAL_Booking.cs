using DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public class DAL_Booking : BaseRepository<_Booking>{
        public DAL_Booking(IMongoCollection<_Booking> collection) : base(collection) {
            this.collection = collection;
        }
    }
}
