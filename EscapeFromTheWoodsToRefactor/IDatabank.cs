using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTheWoods
{
    public interface IDatabank//<W, M> where W : class where M : class
    {
        public void WriteWoodRecords(List<DBWoodRecord> woodData);//(List<W> woodRecords);
        public void WriteMonkeyRecords(List<DBMonkeyRecord> monkeyData);//(List<M> monkeyData);
    }
}
