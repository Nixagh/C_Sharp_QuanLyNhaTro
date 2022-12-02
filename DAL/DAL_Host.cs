using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAL {
    public class DAL_Host : BaseRepository<_Host> {
        public DAL_Host(IMongoCollection<_Host> collection) : base(collection) {
            this.collection = collection;
        }

        public Task updatePost(ObjectId _id, bool status) {
            return collection.UpdateOneAsync(new BsonDocument("_id", _id), new BsonDocument("$set", new BsonDocument("isPost", status)));
        }
    }
}
