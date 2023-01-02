using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MongoDB.Driver;
using DTO;

namespace BUS {
    public class BUS_User {
        DAL_User user = new DAL_User(Connect.getInstance.getDataBase().GetCollection<User>("User"));

        private static bool login = false;
        private static User userAuth = null;

        public static bool isLogin {
            get => login;
            set => login = value;
        }

        public static User UserAuth {
            get => userAuth;
            set => userAuth = value;
        }

        public List<User> findAll() => user.findAll();

        public Task insert(User newUser) => user.insert(newUser);

        public bool checkLogin(string username, string password) {

            var filters = Builders<User>.Filter.Eq(u => u.username, username) &
                            Builders<User>.Filter.Eq(u => u.password, password);
            List<User> result = user.findByConditions(filters);
            if(result != null && result.Count != 0) userAuth = result[0];
            return (result != null && result.Count != 0);
        }

        public void updateRole(MongoDB.Bson.ObjectId _id, string v) {
            var filters = Builders<User>.Filter.Eq(u => u._id, _id);
            var updates = Builders<User>.Update.Set(u => u.Role, v);

            var result = user.update(filters, updates);
        }
    }
}
