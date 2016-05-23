using System;
using System.Collections.Generic;
using System.Xml;
using Data.Unit;

namespace Data.Manager.XML
{
    sealed class PizzaDBManager : DBManagerBase<PizzaDBUnit>
    {
        public override void LoadData()
        {
            base.LoadData("PizzaData");
        }
    }
}