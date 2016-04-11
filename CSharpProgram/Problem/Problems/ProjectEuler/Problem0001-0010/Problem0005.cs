using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0005 : Problem
    {
        private readonly string kQuestion = "1 ~ 10 사이의 어떤 수로도 나누어 떨어지는 가장 작은 수는 2520입니다.\n그러면 1 ~ 20 사이의 어떤 수로도 나누어 떨어지는 가장 작은 수는 얼마입니까?";

        public Problem0005() : base(5) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

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