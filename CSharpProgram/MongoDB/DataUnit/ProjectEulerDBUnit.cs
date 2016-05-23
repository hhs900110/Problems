using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Data.Unit
{
    class ProjectEulerDBUnit : IDBUnitBase
    {
        public ObjectId _id { get; set; }
        public int index { get; set; }
        public string title { get; set; }
        public string question { get; set; }

        public int Index()
        {
            return index;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", index, title, question);
        }
    }
}