using System;
using Data.Unit;

namespace Data.Manager
{
    public interface IDBManager
    {
        void LoadData();
        object GetDataByIndex(int pIndex);
    }
}