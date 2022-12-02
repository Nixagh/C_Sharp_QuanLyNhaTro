using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAL {
    public class BaseRepository<T> {
        protected IMongoCollection<T> collection = null;

        public BaseRepository(IMongoCollection<T> collection) {
            this.collection = collection;
        }

        public List<T> findAll() => this.collection.AsQueryable().ToList<T>();

        public T findOne(FilterDefinition<T> filters) => this.collection.Find(filters).ToList<T>().FirstOrDefault<T>();

        public List<T> findByConditions(FilterDefinition<T> filters) => this.collection.Find(filters).ToList<T>();

        async public Task insert(T doc) => await this.collection.InsertOneAsync(doc);

        async public Task delete(FilterDefinition<T> filters) => await this.collection.FindOneAndDeleteAsync(filters);

        async public Task deleteById(ObjectId _id) => await this.collection.FindOneAndDeleteAsync(new BsonDocument("_id", _id));

        async public Task update(FilterDefinition<T> filters, UpdateDefinition<T> update) => await this.collection.FindOneAndUpdateAsync<T>(filters, update);

        public long countDocument(FilterDefinition<T> filters) => this.collection.CountDocuments(filters);
    }
}
