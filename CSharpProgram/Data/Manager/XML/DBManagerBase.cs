using System;
using System.Collections.Generic;
using System.Xml;
using Data.Unit;

namespace Data.Manager.XML
{
    abstract class DBManagerBase<TDataType> : IDBManager, IXmlParse, IConvertMongoDB
        where TDataType : class, IDBUnitBase, new()
    {
        //파일로딩완료되었는지를 나타내는 식별자
        private bool m_bCompleteLoad = false;
        private Dictionary<int, TDataType> mDicData;

        private string m_fileName = "";

        protected string FildName { get { return m_fileName; } }

        protected DBManagerBase(string fileName)
        {
            m_fileName = fileName;
        }

        public void LoadData()
        {
            if (mDicData == null) { mDicData = new Dictionary<int, TDataType>(); m_bCompleteLoad = false; }
            if (m_bCompleteLoad.Equals(true)) { return; }
            mDicData.Clear();

            XMLSwitcher.LoadFromFile(m_fileName, this);

            m_bCompleteLoad = true;
        }

        public object GetDataByIndex(int pIndex)
        {
            if (mDicData.ContainsKey(pIndex))
            {
                return mDicData[pIndex];
            }
            return new TDataType();
        }

        public bool ParseOne_Reader(XmlReader xmlRead)
        {
            TDataType data = new TDataType();
            data.SetData(xmlRead);

            mDicData.Add(data.Index(), data);

            return true;
        }

        public void ConvertToMongoDB(MongoDB.MongoDBManager mongoDBMng)
        {
            mongoDBMng.ConvertData<TDataType>(FildName, mDicData);
        }
    }
}