using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0010 : Problem
    {
        private readonly string kQuestion = "10 이하의 소수를 모두 더하면 2 + 3 + 5 + 7 = 17 이 됩니다.\n이백만(2,000,000) 이하 소수의 합은 얼마입니까?";

        public Problem0010() : base(10) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            ulong answer = 0;

            answer = SumFactorizeInRange(1, 2000000);

            PrintAnswer(answer.ToString());
        }

        private ulong SumFactorizeInRange(ulong minRange, ulong maxRange)
        {
            ulong returnValue = 0;

            List<ulong> factoList = Calculator.FactorizeList(minRange, maxRange);

            for (int i = 0; i < factoList.Count; ++i)
            {
                returnValue += factoList[i];
            }

            return returnValue;
        }
    }
}