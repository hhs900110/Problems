﻿using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0012 : Problem
    {
        private readonly string kQuestion = "1부터 n까지의 자연수를 차례로 더하여 구해진 값을 삼각수라고 합니다.\n예를 들어 7번째 삼각수는 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28이 됩니다.\n이런 식으로 삼각수를 구해 나가면 다음과 같습니다.\n\t1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...\n이 삼각수들의 약수를 구해봅시다.\n\t 1: 1\n\t 3: 1, 3\n\t 6: 1, 2, 3, 6\n\t10: 1, 2, 5, 10\n\t15: 1, 3, 5, 15\n\t21: 1, 3, 7, 21\n\t28: 1, 2, 4, 7, 14, 28\n위에서 보듯이, 5개 이상의 약수를 갖는 첫번째 삼각수는 28입니다.\n그러면 500개 이상의 약수를 갖는 가장 작은 삼각수는 얼마입니까?";

        public Problem0012() : base(12) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            long answer = 0;

            answer = Find(500);

            PrintAnswer(answer.ToString());
        }

        private long Find(int minDivisorCount)
        {
            long returnValue = 0;
            int count = 1;
            int triangularNumber = 0;

            while (returnValue == 0)
            {
                triangularNumber += count;

                List<long> divisorList = Calculator.Divisor(triangularNumber);

                if (divisorList.Count >= minDivisorCount)
                    returnValue = triangularNumber;

                ++count;
            }

            return returnValue;
        }
    }
}
