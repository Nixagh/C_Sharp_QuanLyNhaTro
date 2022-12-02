using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MongoDB.Driver;

namespace DAL {
    public class DAL_Motel : BaseRepository<_Motel>{
        public DAL_Motel(IMongoCollection<_Motel> collection) : base(collection) {
            this.collection = collection;
        }
    }
}
