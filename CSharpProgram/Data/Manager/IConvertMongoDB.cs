using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Manager
{
    interface IConvertMongoDB
    {
        void ConvertToMongoDB(MongoDB.MongoDBManager mongoDBMng);
    }
}