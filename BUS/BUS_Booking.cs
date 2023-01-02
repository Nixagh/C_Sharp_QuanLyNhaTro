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
        DAL_Booking booking = new DAL_Booking(Connect.getInstance.getDataBase().GetCollection<Booking>("Booking"));

        public List<Booking> getAll() => booking.findAll();

        public List<Booking> getByStatus(bool status) {
            FilterDefinition<Booking> filters = Builders<Booking>.Filter.Eq(b => b.status, status);
            return booking.findByConditions(filters);
        }

        public Booking getByMotel_IdAndStatus(ObjectId id, bool status) {
            FilterDefinition<Booking> filters = Builders<Booking>.Filter.Eq(b => b.status, status) &
                                                 Builders<Booking>.Filter.Eq(b => b.motel_Id, id);

            return booking.findByConditions(filters).FirstOrDefault();
        }

        public Booking getById(ObjectId id) {
            FilterDefinition<Booking> filters = Builders<Booking>.Filter.Eq(b => b._id, id);
            return booking.findByConditions(filters).FirstOrDefault();
        }
        public Task save(Booking b) => booking.insert(b);

        public Task updateStatus(ObjectId id) {
            FilterDefinition<Booking> filters = Builders<Booking>.Filter.Eq(b => b._id, id);
            UpdateDefinition<Booking> update = Builders<Booking>.Update.Set(b => b.status, true)
                                                    .Set(b => b.ngaytra, DateTime.Now.ToString());
            return booking.update(filters, update);
        }
    }
}
