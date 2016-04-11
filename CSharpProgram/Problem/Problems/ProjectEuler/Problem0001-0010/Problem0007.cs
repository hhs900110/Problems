using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0007 : Problem
    {
        public Problem0007() : base(EProblemType.PROJECT_EULER, 7) { }
        
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
                    returnValue = FactoList[(int)num - 1];
                }
                ++checkCount;
            }

            return returnValue;
        }
    }
}