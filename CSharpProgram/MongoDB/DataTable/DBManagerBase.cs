using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Data.Unit;

namespace MongoDBUtil
{
    abstract class DBManagerBase<TDataType>
        where TDataType : class, IDBUnitBase, new()
    {
        protected MongoCollection<TDataType> mDicData;

        public abstract void LoadFromFile();

        protected void LoadFromDB(string dbName)
        {
            MongoDatabase DBTable = Singleton<MongoDBManager>.Instance.DBTable;

            // db 안에 dbName의 컬렉션 (테이블) 가져오기. 만약 없으면 새로 생성.
            mDicData = DBTable.GetCollection<TDataType>(dbName);
        }

        public TDataType GetDataByIndex(int pIndex)
        {
            if (mDicData != null)
            {
                // SELECT - Index 으로 검색
                IMongoQuery queryIndex = Query.EQ("index", pIndex);

                MongoCursor<TDataType> result = mDicData.Find(queryIndex);
                TDataType data = mDicData.FindOne(queryIndex);

                if (data != null)
                {
                    return data;
                }
            }
            return null;
        }

        public void SaveData(IDBUnitBase data)
        {
            mDicData.Save(data);
        }
    }
}