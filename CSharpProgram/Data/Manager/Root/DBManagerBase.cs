using System;
using System.Collections.Generic;
using Data.Unit;

namespace Data.Manager
{
    class DBManagerBase
    {
        private Dictionary<DataType, IDBManager> m_dbList;

        private Dictionary<DataType, IDBManager> DBList
        {
            get
            {
                if (m_dbList == null)
                    m_dbList = new Dictionary<DataType, IDBManager>();
                return m_dbList;
            }
        }

        protected void RegistDBManager(DataType type, IDBManager manager)
        {
            DBList.Add(type, manager);
        }

        public void LoadData()
        {
            foreach (KeyValuePair<DataType, IDBManager> pair in DBList)
            {
                pair.Value.LoadData();
            }
        }

        public IDBManager GetDBManager(DataType type)
        {
            if (DBList.ContainsKey(type))
            {
                return DBList[type];
            }
            return null;
        }
    }
}