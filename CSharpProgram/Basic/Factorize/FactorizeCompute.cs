using System;
using System.Collections.Generic;

namespace Compute.Factorize
{
    public class FactorizeCompute
    {
        private static ulong m_checkRange = 0;
        private static Dictionary<ulong, bool> m_isFactorize = new Dictionary<ulong, bool>(10);

        public static bool IsFactorize(ulong targetValue)
        {
            SieveOfEratostenes(targetValue);

            if (m_isFactorize.ContainsKey(targetValue))
                return m_isFactorize[targetValue];

            return false;
        }

        public static List<ulong> FactorizeList(ulong minRange, ulong maxRange)
        {
            SieveOfEratostenes(maxRange);

            ulong stIndex = Math.Min(minRange, maxRange);
            ulong enIndex = Math.Max(maxRange, minRange);

            List<ulong> factoList = new List<ulong>(10);

            for (ulong i = stIndex; i <= enIndex; ++i)
            {
                if (m_isFactorize.ContainsKey(i))
                {
                    if (m_isFactorize[i])
                    {
                        factoList.Add(i);
                    }
                }
            }

            return factoList;
        }

        private static void SieveOfEratostenes(ulong targetValue)
        {
            for (ulong i = 2; i <= targetValue; ++i)
            {
                // 없었으면 소수임
                if (m_isFactorize.ContainsKey(i) == false)
                {
                    m_isFactorize.Add(i, true);
                }

                if (m_isFactorize[i])
                {
                    ulong j = m_checkRange + i;
                    j -= (j % i); // j 값을 i 의 배수로 맞춰준다.

                    // i의 배수의 값은 모두 False
                    for (; j <= targetValue; j = j + i)
                    {
                        if (i == j)
                            continue;

                        if (m_isFactorize.ContainsKey(j) == false)
                            m_isFactorize.Add(j, false);

                        m_isFactorize[j] = false;
                    }
                }
            }
            m_checkRange = targetValue;
        }
    }
}