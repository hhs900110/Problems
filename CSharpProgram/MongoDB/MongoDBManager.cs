using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoDBUtil
{
    class MongoDBManager
    {
        // Mongo DB를 위한 Connection String
        private readonly string connString = "mongodb://192.168.56.1:27017";

        #region MongoDB
        private MongoClient m_dbClient;
        private MongoServer m_dbServer;
        private MongoDatabase m_database;

        public MongoClient DBClient
        {
            get
            {
                if (m_dbClient == null)
                {
                    // Mongo Client 클라이언트 객체 생성
                    m_dbClient = new MongoClient(connString);
                }
                return m_dbClient;
            }
        }

        public MongoServer DBServer
        {
            get
            {
                if (m_dbServer == null)
                {
                    m_dbServer = DBClient.GetServer();
                }
                return m_dbServer;
            }
        }

        public MongoDatabase DBTable
        {
            get
            {
                if (m_database == null)
                {
                    // 데이터베이스 가져오기
                    // 만약 해당 DB가 없으면 Collection 생성시 새로 생성
                    m_database = DBServer.GetDatabase("db");
                }
                return m_database;
            }
        }
        #endregion

        private ProjectEulerDBManager scriptProjectEulerDB;

        public ProjectEulerDBManager ProjectEulerDB
        {
            get
            {
                if (scriptProjectEulerDB == null)
                {
                    scriptProjectEulerDB = new ProjectEulerDBManager();
                }
                return scriptProjectEulerDB;
            }
        }

        public MongoDBManager()
        {
        }

        public void DataLoad()
        {
            ProjectEulerDB.LoadFromFile();
        }

        public void ConvertData<T>(string collectionName, Dictionary<int, T> dataTable)
            where T : class, Data.Table.IDataBase, new()
        {
            // db 안에 collectionName의 컬렉션 (테이블) 가져오기. 만약 없으면 새로 생성.
            MongoCollection<T> customers = DBTable.GetCollection<T>(collectionName);

            foreach (KeyValuePair<int, T> pair in dataTable)
            {
                T data = pair.Value;

                // SELECT - Name 으로 검색
                IMongoQuery queryIndex = Query.EQ("index", data.Index());

                T result = customers.FindOne(queryIndex);

                if (result != null)
                {
                    customers.Save(data);
                }
                else
                {
                    customers.Insert(data);
                }
            }
        }

        public void DataLoadTest()
        {
            // Mongo DB를 위한 Connection String
            //string connString = "mongodb://localhost";

            //// Mongo Client 클라이언트 객체 생성
            //MongoClient cli = new MongoClient(connString);

            //// 데이터베이스 가져오기
            //// 만약 해당 DB가 없으면 Collection 생성시 새로 생성
            //MongoDatabase testdb = cli.GetServer().GetDatabase("db");

            //// db 안에 Customers 라는 컬렉션 (테이블) 가져오기. 만약 없으면 새로 생성.
            //MongoCollection<CustomerDataUnit> customers = testdb.GetCollection<CustomerDataUnit>("Customers");

            //CustomerDataUnit cust1 = null;

            //string Name = "Han";

            //// SELECT - Name 으로 검색
            //IMongoQuery queryName = Query.EQ("name", Name);
            //var resultbyName = customers.Find(queryName).SingleOrDefault();

            //if (resultbyName != null)
            //{
            //    System.Console.WriteLine(string.Format("[Find By Name]"));
            //    System.Console.WriteLine(cust1.ToString());
            //}

            //// Insert - 컬렉션 객체의 Insert() 메서드 호출
            //// Insert시 _id 라는 자동으로 ObjectID 생성
            //// 이 _id는 해당 Document를 나타내는 키
            //if (cust1 == null)
            //{
            //    cust1 = new CustomerDataUnit { name = "Han", age = 28 };
            //    customers.Insert(cust1);
            //}
            //ObjectId id = cust1.Id;

            //// SELECT - id로 검색
            //IMongoQuery queryID = Query.EQ("_id", id);
            //var resultbyID = customers.Find(queryID);

            //if (resultbyID != null)
            //{
            //    CustomerDataUnit cus = resultbyID.SingleOrDefault();
            //    if (cus != null)
            //    {
            //        System.Console.WriteLine(string.Format("[Find By ID]"));
            //        System.Console.WriteLine(cus.ToString());
            //    }
            //}

            //// UPDATE
            ////    Save() = 전체 Document 갱신
            ////    Update() = 부분 수정
            //{
            //    cust1.age = 30;
            //    customers.Save(cust1);

            //    System.Console.WriteLine(string.Format("[Update Data]"));
            //    System.Console.WriteLine(cust1.ToString());
            //}

            //// DELETE
            ////var qry = Query.EQ("_id", id);
            ////customers.Remove(qry);
        }
    }

}