using System;
using System.Collections.Generic;
using System.Xml;

namespace Data.Table
{
    sealed class ProjectEulerDataTable : DataTableBase<SProblemDataUnit>
    {
        public override void LoadFromFile()
        {
            base.LoadFromFile("ProjectEuler");
        }
    }
}