using System;

namespace Problem.ProjectEuler
{
    class Problem0002 : Problem
    {
        public Problem0002() : base(EProblemType.PROJECT_EULER, 2) { }
        
        public override void Answer()
        {
            int answer = 0;

            {
                int[] fibonacciProgression = new int[] { 1, 2 };

                while (fibonacciProgression[0] <= 4000000)
                {
                    if (fibonacciProgression[0] % 2 == 0)
                    {
                        answer += fibonacciProgression[0];
                    }

                    int nextProgression = fibonacciProgression[0] + fibonacciProgression[1];

                    fibonacciProgression[0] = fibonacciProgression[1];
                    fibonacciProgression[1] = nextProgression;
                }
            }

            PrintAnswer(answer.ToString());
        }
    }
}