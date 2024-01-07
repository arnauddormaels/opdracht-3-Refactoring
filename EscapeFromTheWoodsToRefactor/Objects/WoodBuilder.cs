using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTheWoods
{
    public static class WoodBuilder
    {
        public static Wood GetWood(int size, Map map, string path, IDatabank db)
        {
            Random r = new Random(100);
            List<Tree> trees = new List<Tree>();
            int n = 0;
            List<Task> tasks = new List<Task>();
            object lockObj = new object();

            while (n < size)
            {
                int treeId;
                lock (lockObj)
                {
                    treeId = IDgenerator.GetTreeID();
                }
                int x = r.Next(map.xmin, map.xmax);
                int y = r.Next(map.ymin, map.ymax);
                Tree t;
                t = new Tree(treeId, x, y);

                tasks.Add(Task.Run(() =>
                {
                    if (!trees.Contains(t))
                    {
                        lock (lockObj)
                        {
                        trees.Add(t); n++;

                        }
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());

            Wood w = new Wood(IDgenerator.GetWoodID(), trees, map, path, db);
            return w;
        }
    }
}
