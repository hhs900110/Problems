using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoDBUtil
{
    class MongoDBMain
    {
        public static void DataLoad()
        {
            // Mongo DB를 위한 Connection String
            string connString = "mongodb://localhost";

            // Mongo Client 클라이언트 객체 생성
            MongoClient cli = new MongoClient(connString);

            // 데이터베이스 가져오기
            // 만약 해당 DB가 없으면 Collection 생성시 새로 생성
            MongoDatabase testdb = cli.GetServer().GetDatabase("db");

            // db 안에 Customers 라는 컬렉션 (테이블) 가져오기. 만약 없으면 새로 생성.
            MongoCollection<Customer> customers = testdb.GetCollection<Customer>("Customers");

            Customer cust1 = null;

            string Name = "Han";

            // SELECT - Name 으로 검색
            IMongoQuery queryName = Query.EQ("Name", Name);
            var resultbyName = customers.Find(queryName);

            if (resultbyName != null)
            {
                cust1 = resultbyName.SingleOrDefault();
                if (cust1 != null)
                {
                    System.Console.WriteLine(string.Format("[Find By Name]"));
                    System.Console.WriteLine(cust1.ToString());
                }
            }

            // Insert - 컬렉션 객체의 Insert() 메서드 호출
            // Insert시 _id 라는 자동으로 ObjectID 생성
            // 이 _id는 해당 Document를 나타내는 키
            if (cust1 == null)
            {
                cust1 = new Customer { Name = "Han", Age = 28 };
                customers.Insert(cust1);
            }
            ObjectId id = cust1.Id;

            // SELECT - id로 검색
            IMongoQuery queryID = Query.EQ("_id", id);
            var resultbyID = customers.Find(queryID);

            if (resultbyID != null)
            {
                Customer cus = resultbyID.SingleOrDefault();
                if (cus != null)
                {
                    System.Console.WriteLine(string.Format("[Find By ID]"));
                    System.Console.WriteLine(cus.ToString());
                }
            }

            // UPDATE
            //    Save() = 전체 Document 갱신
            //    Update() = 부분 수정
            {
                cust1.Age = 30;
                customers.Save(cust1);

                System.Console.WriteLine(string.Format("[Update Data]"));
                System.Console.WriteLine(cust1.ToString());
            }

            // DELETE
            //var qry = Query.EQ("_id", id);
            //customers.Remove(qry);
        }
    }

    class Customer
    {
        // 이 Id는 MongoDB Collection의 _id 컬럼과 매칭됨
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}