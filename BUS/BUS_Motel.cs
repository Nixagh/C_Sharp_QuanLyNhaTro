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
        DAL_Motel motel = new DAL_Motel(Connect.getInstance.getDataBase().GetCollection<_Motel>("Motel"));

        public Task insert(_Motel newMotel) => motel.insert(newMotel);
        public List<_Motel> getByHostId(ObjectId _id) {
            FilterDefinition<_Motel> filter = Builders<_Motel>.Filter.Eq(m => m.hostId, _id);
            return motel.findByConditions(filter);
        }
        public Task delete(ObjectId _id) {
            /*FilterDefinition<_Motel> filter = Builders<_Motel>.Filter.Eq(m => m.hostId, _id);*/
            return motel.deleteById(_id);
        } 
    }
}
