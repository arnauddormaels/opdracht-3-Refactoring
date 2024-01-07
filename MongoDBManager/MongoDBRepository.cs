using EscapeFromTheWoods;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBManager
{
    public class MongoDBRepository : IDatabank
    {

        private IMongoClient dbClient;
        private IMongoDatabase database;
        private string connectionString;
        private IMongoCollection<MongoDBMonkeyRecord> monkeyRecordsCollection;
        private IMongoCollection<MongoDBWoodRecord> woodRecordsCollection;


        public MongoDBRepository(string connectionString)
        {
            this.connectionString = connectionString;
            dbClient = new MongoClient(connectionString);
            database = dbClient.GetDatabase("monkeys");
            monkeyRecordsCollection = database.GetCollection<MongoDBMonkeyRecord>("monkeyRecords");
            woodRecordsCollection = database.GetCollection<MongoDBWoodRecord>("woodRecords");
        }

        public void WriteMonkeyRecords(List<DBMonkeyRecord> monkeyData)
        {
            //  var collection = database.GetCollection<DBMonkeyRecord>("monkeyRecords");
            //  collection.InsertMany(monkeyData);
            MongoDBMonkeyRecord monkeyRecord = new MongoDBMonkeyRecord(monkeyData);
            monkeyRecordsCollection.InsertOne(monkeyRecord);


        }

        public void WriteWoodRecords(List<DBWoodRecord> woodData)
        {
            MongoDBWoodRecord woodRecord = new MongoDBWoodRecord(woodData);
            // var collection = database.GetCollection<DBWoodRecord>("woodRecords");           //Collection is soms null
            //collection.InsertMany(woodData);
            woodRecordsCollection.InsertOne(woodRecord);
        }
    }
}
