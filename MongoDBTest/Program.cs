using EscapeFromTheWoods;
using MongoDBManager;
using System.Diagnostics;

namespace MongoDBTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Data Source =.; Initial Catalog = ParkbeheerOpgave; Integrated Security = True;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Hello World!");
            //mongodb://localhost:27017
            string connectionString = @"mongodb://localhost:27017";
            IDatabank db = new MongoDBRepository(connectionString);

            string path = @"C:\Users\arnau\OneDrive\Documenten\school\graduaat 3e semester\Programmeren specialisatie\opdracht 3 Refactoring\woodImages"; //@"C:\NET\monkeys";

            List<Task> tasks = new List<Task>();

            Map m1;
            Wood w1;
            tasks.Add(Task.Run(() =>
            {
                m1 = new Map(0, 500, 0, 500);
                w1 = WoodBuilder.GetWood(500, m1, path, db);
                w1.PlaceMonkey("Alice", IDgenerator.GetMonkeyID());
                w1.PlaceMonkey("Janice", IDgenerator.GetMonkeyID());
                w1.PlaceMonkey("Toby", IDgenerator.GetMonkeyID());
                w1.PlaceMonkey("Mindy", IDgenerator.GetMonkeyID());
                w1.PlaceMonkey("Jos", IDgenerator.GetMonkeyID());
                w1.WriteWoodToDB();
                w1.Escape();


            }));
            Map m2;
            Wood w2;
            tasks.Add(Task.Run(() =>
            {
                m2 = new Map(0, 200, 0, 400);
                w2 = WoodBuilder.GetWood(2500, m2, path, db);
                w2.PlaceMonkey("Tom", IDgenerator.GetMonkeyID());
                w2.PlaceMonkey("Jerry", IDgenerator.GetMonkeyID());
                w2.PlaceMonkey("Tiffany", IDgenerator.GetMonkeyID());
                w2.PlaceMonkey("Mozes", IDgenerator.GetMonkeyID());
                w2.PlaceMonkey("Jebus", IDgenerator.GetMonkeyID());
                w2.WriteWoodToDB();
                w2.Escape();

            }));
            Map m3;
            Wood w3;
            tasks.Add(Task.Run(() =>
            {
                m3 = new Map(0, 400, 0, 400);
                w3 = WoodBuilder.GetWood(2000, m3, path, db);
                w3.PlaceMonkey("Kelly", IDgenerator.GetMonkeyID());
                w3.PlaceMonkey("Kenji", IDgenerator.GetMonkeyID());
                w3.PlaceMonkey("Kobe", IDgenerator.GetMonkeyID());
                w3.PlaceMonkey("Kendra", IDgenerator.GetMonkeyID());
                w3.WriteWoodToDB();
                w3.Escape();

            }));

            /*
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => w1.WriteWoodToDB()));
            tasks.Add(Task.Run(() => w1.WriteWoodToDB()));
            tasks.Add(Task.Run(() => w1.WriteWoodToDB()));
           */

            /*
             * w1.WriteWoodToDB();
            w2.WriteWoodToDB();
            w3.WriteWoodToDB();
            */
            /*
             List<Task> tasks1 = new List<Task>();
             tasks1.Add(Task.Run(() =>w1.Escape()));
             tasks1.Add(Task.Run(() => w2.Escape()));
             tasks1.Add(Task.Run(() => w3.Escape()));
            */
            /*
            w1.Escape();
            w2.Escape();
            w3.Escape();
            */

            Task.WaitAll(tasks.ToArray());

            stopwatch.Stop();
            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("end");






        }

    }
}
