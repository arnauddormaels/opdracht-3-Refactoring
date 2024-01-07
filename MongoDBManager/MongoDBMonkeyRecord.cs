using EscapeFromTheWoods;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBManager
{
    public class MongoDBMonkeyRecord
    {
        public MongoDBMonkeyRecord(List<DBMonkeyRecord> monkeyRecords)
        {
            this.monkeyRecords = monkeyRecords;
        }

        public ObjectId id { get; set; }
        public List<DBMonkeyRecord> monkeyRecords { get; set; }

    }
}
