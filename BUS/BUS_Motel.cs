using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BUS {
    public class BUS_Motel {
        DAL_Motel motel = new DAL_Motel(Connect.getInstance.getDataBase().GetCollection<Motel>("Motel"));

        public Task insert(Motel newMotel) => motel.insert(newMotel);
        public List<Motel> getByHostId(ObjectId _id) {
            FilterDefinition<Motel> filter = Builders<Motel>.Filter.Eq(m => m.hostId, _id);
            return motel.findByConditions(filter);
        }
        public List<Motel> getByHostIdAndStatus(ObjectId _id) {
            FilterDefinition<Motel> filter = Builders<Motel>.Filter.Eq(m => m.hostId, _id) &
                                              Builders<Motel>.Filter.Eq(m => m.status, "Trống");
            return motel.findByConditions(filter);
        }
        public Task delete(ObjectId _id) {
            /*FilterDefinition<_Motel> filter = Builders<_Motel>.Filter.Eq(m => m.hostId, _id);*/
            return motel.deleteById(_id);
        }

        public void updateStatus(ObjectId id, string status) {
            FilterDefinition<Motel> filter = Builders<Motel>.Filter.Eq(m => m._id, id);

            UpdateDefinition<Motel> update = Builders<Motel>.Update.Set(m => m.status, status);
            _ = motel.update(filter, update);
        }
    }
}
