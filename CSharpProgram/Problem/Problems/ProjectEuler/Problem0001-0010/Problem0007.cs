using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0007 : Problem
    {
        private readonly string kQuestion = "소수를 크기 순으로 나열하면 2, 3, 5, 7, 11, 13, ... 과 같이 됩니다.\n이 때 10,001번째의 소수를 구하세요.";

        public Problem0007() : base(7) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            ulong answer = 0;

            answer = FindNumOfFactorize(10001);

            PrintAnswer(answer.ToString());
        }

        private ulong FindNumOfFactorize(uint num)
        {
            ulong returnValue = 0;
            uint checkCount = 0;

            while (returnValue == 0)
            {
                List<ulong> FactoList = Calculator.FactorizeList(0, (ulong)(checkCount * num));

                if (FactoList.Count >= num)
                {
                    returnValue = FactoList[(int)num-1];
                }
                ++checkCount;
            }

            return returnValue;
        }
    }
}