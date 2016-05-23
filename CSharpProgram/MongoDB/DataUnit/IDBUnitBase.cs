using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Data.Unit
{
    // MongoDB 객체 맵핑은 class만 가능하다
    interface IDBUnitBase
    {
        int Index();
        string ToString();
    }
}