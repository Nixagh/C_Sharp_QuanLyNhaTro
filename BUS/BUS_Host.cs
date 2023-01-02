using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.RegularExpressions;

namespace BUS {
    public class BUS_Host {
        DAL_Host host = new DAL_Host(Connect.getInstance.getDataBase().GetCollection<Host>("Host"));

        public Task insert(Host newHost) => host.insert(newHost);

        public List<Host> getAll() => host.findAll(); 

        public Host findByUserId(ObjectId userId) {
            FilterDefinition<Host> filters = Builders<Host>.Filter.Eq(h => h.user_Id, userId);
            return host.findOne(filters);
        }

        public Task changePost(ObjectId userId, bool status) {
            return host.updatePost(userId, status);
        }

        public List<Host> getAllByPost() {
            FilterDefinition<Host> filters = Builders<Host>.Filter.Eq(h => h.isPost, true);
            return host.findByConditions(filters);
        }

        public Task update(ObjectId _id, string name, Address address, string addressDetail, string facebook, string image, string phoneNum) {
            FilterDefinition<Host> filters = Builders<Host>.Filter.Eq(h => h._id, _id);
            UpdateDefinition<Host> updates = Builders<Host>.Update
                                                    .Set(h => h.name, name)
                                                    .Set(h => h.address, address)
                                                    .Set(h => h.addressDetail, addressDetail)
                                                    .Set(h => h.facebook, facebook)
                                                    .Set(h => h.image, image)
                                                    .Set(h => h.phoneNumber, phoneNum);
            return host.update(filters, updates);
        }

        public List<Host> getByPostAndAddress(Address address) {
            var filters = Builders<Host>.Filter.Empty;
            if (!string.IsNullOrEmpty(address.Tinh))
                filters = Builders<Host>.Filter.Eq(h => h.address.Tinh, address.Tinh);
            if(!string.IsNullOrEmpty(address.Huyen))
                filters &= Builders<Host>.Filter.Eq(h => h.address.Huyen, address.Huyen);
            if (!string.IsNullOrEmpty(address.Xa))
                filters &= Builders<Host>.Filter.Eq(h => h.address.Xa, address.Xa);

            filters &= Builders<Host>.Filter.Eq(h => h.isPost, true);
            return host.findByConditions(filters);
        }

        public List<Host> getByPostAndSearch(string key) {
            var queryExpr = new BsonRegularExpression(new Regex(key, RegexOptions.IgnoreCase));
            if (string.IsNullOrEmpty(key))
                return getAllByPost();
            var filters = Builders<Host>.Filter.Regex(h => h.name, queryExpr) 
                            & Builders<Host>.Filter.Eq(h => h.isPost, true);
            return host.findByConditions(filters);
        }
    }
}
