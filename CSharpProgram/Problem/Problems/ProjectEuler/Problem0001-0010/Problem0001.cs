using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0001 : Problem
    {
        public Problem0001() : base(EProblemType.PROJECT_EULER, 1) { }
        
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