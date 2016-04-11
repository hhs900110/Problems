using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0005 : Problem
    {
        public Problem0005() : base(EProblemType.PROJECT_EULER, 5) { }
        
        public override void Answer()
        {
            long answer = 0;

            answer = LCMByRange(1, 20);

            PrintAnswer(answer.ToString());
        }

        private long LCMByRange(int minRange, int maxRange)
        {
            long returnValue = 1;

            Dictionary<long, int> dicNeedFactorize = new Dictionary<long, int>(2);

            for (int i = minRange; i < maxRange; ++i)
            {
                Dictionary<long, int> tmpDic = GetFactorizeNum(i);
                List<long> keys = new List<long>(tmpDic.Keys);

                for (int j = 0; j < keys.Count; ++j)
                {
                    if (dicNeedFactorize.ContainsKey(keys[j]))
                    {
                        if (dicNeedFactorize[keys[j]] < tmpDic[keys[j]])
                        {
                            dicNeedFactorize[keys[j]] = tmpDic[keys[j]];
                        }
                    }
                    else
                    {
                        dicNeedFactorize.Add(keys[j], tmpDic[keys[j]]);
                    }
                }
            }

            List<long> needKeys = new List<long>(dicNeedFactorize.Keys);

            for (int i = 0; i < needKeys.Count; ++i)
            {
                int count = dicNeedFactorize[needKeys[i]];
                for (int j = 0; j < count; ++j)
                {
                    returnValue *= needKeys[i];
                }
            }

            return returnValue;
        }

        private Dictionary<long, int> GetFactorizeNum(int pTarget)
        {
            Dictionary<long, int> returnDic = new Dictionary<long, int>(2);

            List<long> lstIntegerFactorization = Calculator.IntegerFactorization(pTarget);
            lstIntegerFactorization.Sort();

            for (int i = 0; i < lstIntegerFactorization.Count; ++i)
            {
                if (returnDic.ContainsKey(lstIntegerFactorization[i]))
                {
                    returnDic[lstIntegerFactorization[i]]++;
                }
                else
                {
                    returnDic.Add(lstIntegerFactorization[i], 1);
                }
            }

            return returnDic;
        }
    }
}