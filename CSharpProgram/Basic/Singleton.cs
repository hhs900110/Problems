using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Singleton<TClass>
    where TClass : class, new()
{
    private static TClass mInstance;
    public static TClass Instance
    {
        get
        {
            if (mInstance.Equals(null))
            {
                mInstance = new TClass();
            }
            return mInstance;
        }
    }
}