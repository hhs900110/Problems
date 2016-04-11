using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0003 : Problem
    {
        public Problem0003() : base(EProblemType.PROJECT_EULER, 3) { }
        
        public override void Answer()
        {
            long answer = 0;

            List<long> integerFactorize = Calculator.IntegerFactorization(600851475143);
            answer = Calculator.Max(integerFactorize);

            PrintAnswer(answer.ToString());
        }
    }
}