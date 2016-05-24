using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class DBManager
    {
        private Data.Manager.MongoDB.MongoDBManager mongoDBMng;
        private Data.Manager.XML.XmlDBManager xmlDBMng;

        public DBManager()
        {
            mongoDBMng = new Data.Manager.MongoDB.MongoDBManager();
            xmlDBMng = new Data.Manager.XML.XmlDBManager();
        }

        public void DataLoad()
        {
            mongoDBMng.LoadData();
            //xmlDBMng.LoadData();

            //xmlDBMng.ConvertToMongoDB(mongoDBMng);
        }

        public IDBManager GetDBManager(DataType type)
        {
            IDBManager dbManager = mongoDBMng.GetDBManager(type);
            if (dbManager == null)
            {
                dbManager = xmlDBMng.GetDBManager(type);
            }
            return dbManager;
        }
    }

    public enum DataType
    {
        ProjectEuler,
    }
}