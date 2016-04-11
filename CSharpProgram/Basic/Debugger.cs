using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Debugger
{
    public static void Log(string log)
    {
        Console.WriteLine(string.Format("{0}", log));
    }

    public static void LogWarning(string log)
    {
        Console.WriteLine(string.Format("[Warning] {0}", log));
    }

    public static void LogError(string log)
    {
        Console.WriteLine(string.Format("[ERROR] {0}", log));
    }
}