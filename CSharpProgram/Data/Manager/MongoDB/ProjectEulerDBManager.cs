using System;
using System.Collections.Generic;
using Data.Unit;

namespace Data.Manager.MongoDB
{
    class ProjectEulerDBManager : DBManagerBase<ProjectEulerDBUnit>
    {
        public override void LoadData()
        {
            LoadData("ProjectEuler");
        }
    }
}