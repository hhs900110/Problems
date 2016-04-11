using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0012 : Problem
    {
        public Problem0012() : base(EProblemType.PROJECT_EULER, 12) { }
        
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