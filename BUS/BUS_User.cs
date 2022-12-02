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
        DAL_User user = new DAL_User(Connect.getInstance.getDataBase().GetCollection<_User>("User"));

        private static bool login = false;
        private static _User userAuth = null;

        public static bool isLogin {
            get => login;
            set => login = value;
        }

        public static _User UserAuth {
            get => userAuth;
            set => userAuth = value;
        }

        public List<_User> findAll() => user.findAll();

        public Task insert(_User newUser) => user.insert(newUser);

        public bool checkLogin(string username, string password) {

            var filters = Builders<_User>.Filter.Eq(u => u.username, username) &
                            Builders<_User>.Filter.Eq(u => u.password, password);
            List<_User> result = user.findByConditions(filters);
            if(result != null && result.Count != 0) userAuth = result[0];
            return (result != null && result.Count != 0);
        }

    }
}
