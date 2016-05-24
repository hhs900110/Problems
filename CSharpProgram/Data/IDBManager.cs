using System;
using Data.Unit;

namespace Data
{
    public interface IDBManager
    {
        void LoadData();
        object GetDataByIndex(int pIndex);
    }
}