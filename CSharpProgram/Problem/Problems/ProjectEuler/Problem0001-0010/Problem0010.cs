using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0010 : Problem
    {
        public Problem0010() : base(EProblemType.PROJECT_EULER, 10) { }
        
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