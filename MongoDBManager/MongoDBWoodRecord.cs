using EscapeFromTheWoods;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBManager
{
    public class MongoDBWoodRecord
    {
        public MongoDBWoodRecord(List<DBWoodRecord> woordRecords)
        {
            this.woordRecords = woordRecords;
        }

        public ObjectId id {  get; set; }
      //  public Wood wood { get; set; }
        public List<DBWoodRecord> woordRecords { get; set; }
    }
}
