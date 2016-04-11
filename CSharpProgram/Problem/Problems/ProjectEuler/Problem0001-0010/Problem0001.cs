using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0001 : Problem
    {
        private readonly string[] kQuestion = new string[] {
            "10보다 작은 자연수 중에서 3 또는 5의 배수는 3, 5, 6, 9 이고,",
            "이것을 모두 더하면 23입니다.",
            "1000보다 작은 자연수 중에서 3 또는 5의 배수를 모두 더하면 얼마일까요?" };

        public Problem0001() : base(1) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            int answer = 0;

            List<int> multipleList = FindMultiple(1000, 3, 5);
            answer = Calculator.Sum(multipleList);

            PrintAnswer(answer.ToString());
        }

        private List<int> FindMultiple(int maxNumber, params int[] pNumber)
        {
            List<int> returnList = new List<int>(2);

            for (int i = 0; i < maxNumber; ++i)
            {
                for (int j = 0; j < pNumber.Length; ++j)
                {
                    if (i % pNumber[j] == 0)
                    {
                        returnList.Add(i);
                        break;
                    }
                }
            }

            return returnList;
        }
    }
}