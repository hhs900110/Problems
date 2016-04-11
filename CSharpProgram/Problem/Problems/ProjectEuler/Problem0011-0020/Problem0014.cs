using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0014 : Problem
    {
        public Problem0014() : base(EProblemType.PROJECT_EULER, 14) { }
        
        public override void Answer()
        {
            ulong answer = 0;

            answer = Find(1000000);

            PrintAnswer(answer.ToString());
        }

        private ulong Find(ulong maxValue)
        {
            ulong returnValue = 0;
            ulong maxCount = ulong.MinValue;

            for (ulong i = 1; i <= maxValue; ++i)
            {
                ulong count = CollatzConjecture(i);
                if (maxCount < count)
                {
                    returnValue = i;
                    maxCount = count;
                }
            }

            return returnValue;
        }

        private ulong CollatzConjecture(ulong hailstoneSequence)
        {
            ulong returnValue = 0;
            ulong compute = hailstoneSequence;

            while (compute > 1)
            {
                if (compute % 2 == 0)
                {
                    //n → n / 2 (n이 짝수일 때)
                    compute = compute / 2;
                }
                else
                {
                    //n → 3 n + 1 (n이 홀수일 때)
                    compute = (3 * compute) + 1;
                }
                ++returnValue;
            }

            return returnValue;
        }
    }
}
