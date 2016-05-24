using System;
using System.Collections.Generic;
using System.Xml;
using Data.Unit;

namespace Data.Manager.XML
{
    sealed class ProjectEulerDBManager : DBManagerBase<ProjectEulerDBUnit>
    {
        public ProjectEulerDBManager() : base("ProjectEuler") { }
    }
}