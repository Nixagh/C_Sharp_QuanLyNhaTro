using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BUS {
    public class BUS_Host {
        DAL_Host host = new DAL_Host(Connect.getInstance.getDataBase().GetCollection<_Host>("Host"));

        public Task insert(_Host newHost) => host.insert(newHost);

        public List<_Host> getAll() => host.findAll(); 

        public _Host findByUserId(ObjectId userId) {
            FilterDefinition<_Host> filters = Builders<_Host>.Filter.Eq(h => h.user_Id, userId);
            return host.findOne(filters);
        }

        public Task changePost(ObjectId userId, bool status) {
            return host.updatePost(userId, status);
        }

        public List<_Host> getAllByPost() {
            FilterDefinition<_Host> filters = Builders<_Host>.Filter.Eq(h => h.isPost, true);
            return host.findByConditions(filters);
        }

        public Task update(ObjectId _id, string name, Address address, string addressDetail, string facebook, string image, string phoneNum) {
            FilterDefinition<_Host> filters = Builders<_Host>.Filter.Eq(h => h._id, _id);
            UpdateDefinition<_Host> updates = Builders<_Host>.Update
                                                    .Set(h => h.name, name)
                                                    .Set(h => h.address, address)
                                                    .Set(h => h.addressDetail, addressDetail)
                                                    .Set(h => h.facebook, facebook)
                                                    .Set(h => h.image, image)
                                                    .Set(h => h.phoneNumber, phoneNum);
            return host.update(filters, updates);
        }
    }
}
