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
            xmlDBMng.LoadData();
        }

        public Data.Manager.IDBManager GetDBManager(DataType type)
        {
            Data.Manager.IDBManager dbManager = mongoDBMng.GetDBManager(type);
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