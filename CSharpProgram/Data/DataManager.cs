using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataManager
    {
        public static void DataLoad()
        {
            Singleton<MongoDBUtil.MongoDBManager>.Instance.DataLoad();

            //Singleton<Table.PizzaDataTable>.Instance.LoadFromFile();
            //Singleton<Table.ProjectEulerDataTable>.Instance.LoadFromFile();

        }
    }
}