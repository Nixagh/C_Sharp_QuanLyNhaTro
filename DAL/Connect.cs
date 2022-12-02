using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL {
    public class Connect {
        private static Connect _instance = null;

        private Connect() { }

        public static Connect getInstance {
            get {
                if (_instance == null)
                    _instance = new Connect();
                return _instance;
            }
        }

        public IMongoDatabase getDataBase() {
            /*string uri = "mongodb://localhost:27017";*/
            string uri = "mongodb+srv://Nixagh:nghia123@csharp.ezeo8yu.mongodb.net/?retryWrites=true&w=majority"
  ;          MongoClient mongoClient = new MongoClient(uri);
            return mongoClient.GetDatabase("CSharp_Mongo");
        }
    }
}
