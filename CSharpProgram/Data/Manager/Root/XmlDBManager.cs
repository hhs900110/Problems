using System;
using System.Collections.Generic;
using System.Xml;

namespace Data.Manager.XML
{
    class XmlDBManager : RootDBManagerBase, IConvertMongoDB
    {
        public XmlDBManager()
        {
            RegistDBManager(DataType.ProjectEuler, new ProjectEulerDBManager());
        }

        public void ConvertToMongoDB(MongoDB.MongoDBManager mongoDBMng)
        {
            foreach (KeyValuePair<DataType, object> pair in DBList)
            {
                ((IConvertMongoDB)pair.Value).ConvertToMongoDB(mongoDBMng);
            }
        }
    }
}