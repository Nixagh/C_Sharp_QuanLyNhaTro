using DAL;
using DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS {
    public class BUS_Booking {
        DAL_Booking booking = new DAL_Booking(Connect.getInstance.getDataBase().GetCollection<_Booking>("Booking"));

        public List<_Booking> getAll() => booking.findAll();

        public List<_Booking> getByStatus(bool status) {
            FilterDefinition<_Booking> filters = Builders<_Booking>.Filter.Eq(b => b.status, status);
            return booking.findByConditions(filters);
        }

        public _Booking getByMotel_IdAndStatus(ObjectId id, bool status) {
            FilterDefinition<_Booking> filters = Builders<_Booking>.Filter.Eq(b => b.status, status) &
                                                 Builders<_Booking>.Filter.Eq(b => b.motel_Id, id);

            return booking.findByConditions(filters).FirstOrDefault();
        }

        public _Booking getById(ObjectId id) {
            FilterDefinition<_Booking> filters = Builders<_Booking>.Filter.Eq(b => b._id, id);
            return booking.findByConditions(filters).FirstOrDefault();
        }
        public Task save(_Booking b) => booking.insert(b);

        public Task updateStatus(ObjectId id) {
            FilterDefinition<_Booking> filters = Builders<_Booking>.Filter.Eq(b => b._id, id);
            UpdateDefinition<_Booking> update = Builders<_Booking>.Update.Set(b => b.status, true)
                                                    .Set(b => b.ngaytra, DateTime.Now.ToString());
            return booking.update(filters, update);
        }
    }
}
