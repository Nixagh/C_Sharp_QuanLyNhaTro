using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MongoDB.Driver;

namespace DAL {
    public class DAL_User : BaseRepository<User> {
        public DAL_User(IMongoCollection<User> collection) : base(collection) {
            this.collection = collection;
        }
    }
}
