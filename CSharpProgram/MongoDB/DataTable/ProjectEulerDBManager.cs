using System;
using System.Collections.Generic;
using Data.Unit;

namespace MongoDBUtil
{
    class ProjectEulerDBManager : DBManagerBase<ProjectEulerDBUnit>
    {
        public override void LoadFromFile()
        {
            LoadFromDB("ProjectEuler");
        }
    }
}