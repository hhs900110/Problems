using System;
using System.Collections.Generic;
using Data.Unit;

namespace Data.Manager
{
    class RootDBManagerBase
    {
        private Dictionary<DataType, object> m_dbList;

        protected Dictionary<DataType, object> DBList
        {
            get
            {
                if (m_dbList == null)
                    m_dbList = new Dictionary<DataType, object>();
                return m_dbList;
            }
        }

        protected void RegistDBManager(DataType type, object manager)
        {
            DBList.Add(type, manager);
        }

        public void LoadData()
        {
            foreach (KeyValuePair<DataType, object> pair in DBList)
            {
                ((IDBManager)pair.Value).LoadData();
            }
        }

        public IDBManager GetDBManager(DataType type)
        {
            if (DBList.ContainsKey(type))
            {
                return (IDBManager)DBList[type];
            }
            return null;
        }
    }
}