using System;
using System.Xml;

namespace Data.Unit
{
    // MongoDB 객체 맵핑은 class만 가능하다
    interface IDBUnitBase
    {
        int Index();
        string ToString();
        void SetData(XmlReader xmlRead);
    }
}