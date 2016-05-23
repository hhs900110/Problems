using System;
using System.Xml;

namespace Data.Unit
{
    class PizzaDBUnit : IDBUnitBase
    {
        private int mPizzaIndex;
        private string mPizzaName;
        private int mPizzaPrice;

        public int Index() { return PizzaIndex; }

        public int PizzaIndex { get { return mPizzaIndex; } }
        public string PizzaName { get { return mPizzaName; } }
        public int PizzaPrice { get { return mPizzaPrice; } }

        public void SetData(XmlReader xmlRead)
        {
            XMLSwitcher.TryParse(xmlRead, "PizzaIndex", out mPizzaIndex);
            XMLSwitcher.TryParse(xmlRead, "PizzaName", out mPizzaName);
            XMLSwitcher.TryParse(xmlRead, "PizzaPrice", out mPizzaPrice);
        }
    }
}
