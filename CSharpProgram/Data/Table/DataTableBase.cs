using System;
using System.Collections.Generic;
using System.Xml;

namespace Data.Table
{
    abstract class DataTableBase<TDataType> : IXmlParse
        where TDataType : class, IDataBase, new()
    {
        //파일로딩완료되었는지를 나타내는 식별자
        private bool m_bCompleteLoad = false;

        public Dictionary<int, TDataType> mDicData;

        public abstract void LoadFromFile();

        protected void LoadFromFile(string xmlFileName)
        {
            if (mDicData == null) { mDicData = new Dictionary<int, TDataType>(); m_bCompleteLoad = false; }
            if (m_bCompleteLoad.Equals(true)) { return; }
            mDicData.Clear();

            XMLSwitcher.LoadFromFile(xmlFileName, this);

            m_bCompleteLoad = true;
        }

        public bool ParseOne_Reader(XmlReader xmlRead)
        {
            TDataType data = new TDataType();
            data.SetData(xmlRead);

            mDicData.Add(data.Index(), data);

            return true;
        }

        public TDataType GetDataByIndex(int pIndex)
        {
            if (mDicData.ContainsKey(pIndex))
            {
                return mDicData[pIndex];
            }
            return new TDataType();
        }
    }

    interface IDataBase
    {
        void SetData(XmlReader xmlRead);
        int Index();
    }
}