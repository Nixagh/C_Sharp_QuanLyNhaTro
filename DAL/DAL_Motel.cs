﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MongoDB.Driver;

namespace DAL {
    public class DAL_Motel : BaseRepository<Motel>{
        public DAL_Motel(IMongoCollection<Motel> collection) : base(collection) {
            this.collection = collection;
        }
    }
}
