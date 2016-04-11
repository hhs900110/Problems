using System;
using System.Collections.Generic;
using Compute.Factorize;

class Calculator
{
    /// <summary> Target 을 소인수분해 했을 때 나오는 인수 리스트 </summary>
    public static List<long> IntegerFactorization(long pTarget)
    {
        List<long> returnList = new List<long>();
        long compute = pTarget;

        // 음수의 값을 넣었을 경우에 -1 처리를 한번 해준다.
        if (compute < 0)
        {
            returnList.Add(-1);
            compute *= -1;
        }

        double maxValue = 0;
        int count = 0;
        long plus = 0;
        long minus = 0;

        // 계산값이 1이 될 때까지 돌린다.
        while (compute > 1)
        {
            long factorize = 0;

            for (int i = 2; i <= 3; ++i)
            {
                // 2 또는 3으로 나뉘어지는지 체크
                if (compute % i == 0)
                {
                    factorize = i;
                    break;
                }
            }

            if (factorize == 0)
            {
                maxValue = Math.Sqrt(compute);
                count = 0;
                plus = 0;
                minus = 0;

                while (factorize == 0)
                {
                    count++;
                    plus = 6 * count + 1;
                    minus = 6 * count - 1;

                    if (compute % minus == 0)
                    {
                        factorize = minus;
                    }
                    else if (compute % plus == 0)
                    {
                        factorize = plus;
                    }

                    if(minus > maxValue)
                        break;
                }
            }

            if (factorize == 0)
            {
                factorize = compute;
            }

            compute = compute / factorize;
            returnList.Add(factorize);
        }

        return returnList;
    }

    /// <summary> Target 이 소수인지 체크 </summary>
    public static bool IsFactorize(ulong pTarget)
    {
        return FactorizeCompute.IsFactorize(pTarget);
    }

    public static List<ulong> FactorizeList(ulong minRange, ulong maxRange)
    {
        return FactorizeCompute.FactorizeList(minRange, maxRange);
    }

    /// <summary> Target 의 약수 리스트 </summary>
    public static List<long> Divisor(long pTarget)
    {
        List<long> returnList = new List<long>();
        double maxValue = pTarget/2;

        for (int i = 1; i <= maxValue; ++i)
        {
            if (pTarget % i == 0)
            {
                returnList.Add(i);
            }
        }

        if (pTarget.Equals(1) == false)
            returnList.Add(pTarget);

        return returnList;
    }

    public static int Sum(params int[] pNumber)
    {
        int returnValue = 0;

        if (pNumber == null)
        {
            return returnValue;
        }

        for (int i = 0; i < pNumber.Length; ++i)
        {
            returnValue += pNumber[i];
        }

        return returnValue;
    }

    public static int Sum(List<int> pList)
    {
        int returnValue = 0;

        if (pList == null)
        {
            return returnValue;
        }

        for (int i = 0; i < pList.Count; ++i)
        {
            returnValue += pList[i];
        }

        return returnValue;
    }

    public static int Multiple(params int[] pNumber)
    {
        int returnValue = 0;

        if (pNumber == null)
        {
            return returnValue;
        }

        returnValue = 1;

        for (int i = 0; i < pNumber.Length; ++i)
        {
            returnValue *= pNumber[i];
        }

        return returnValue;
    }

    public static int Multiple(List<int> pList)
    {
        int returnValue = 0;

        if (pList == null)
        {
            return returnValue;
        }

        returnValue = 1;

        for (int i = 0; i < pList.Count; ++i)
        {
            returnValue *= pList[i];
        }

        return returnValue;
    }

    public static int Clamp(int x, int low, int high)
    {
        
        return Math.Min(Math.Max(x, low), high);
    }

    #region Min & Max
    public static int Min(List<int> pList)
    {
        if (pList == null)
            return 0;

        pList.Sort();
        return (pList.Count > 0 ? pList[0] : 0);
    }

    public static long Min(List<long> pList)
    {
        if (pList == null)
            return 0;

        pList.Sort();
        return (pList.Count > 0 ? pList[0] : 0);
    }

    public static int Max(List<int> pList)
    {
        if (pList == null)
            return 0;

        pList.Sort();
        return (pList.Count > 0 ? pList[pList.Count - 1] : 0);
    }

    public static long Max(List<long> pList)
    {
        if (pList == null)
            return 0;

        pList.Sort();
        return (pList.Count > 0 ? pList[pList.Count - 1] : 0);
    }
    #endregion
}