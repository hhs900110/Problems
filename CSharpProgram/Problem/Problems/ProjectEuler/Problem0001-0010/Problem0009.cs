using System;

namespace Problem.ProjectEuler
{
    class Problem0009 : Problem
    {
        public Problem0009() : base(EProblemType.PROJECT_EULER, 9) { }
        
        public override void Answer()
        {
            int answer = 0;

            answer = Calculator.Multiple(FindPythagorasNumber(1000));

            PrintAnswer(answer.ToString());
        }

        private int[] FindPythagorasNumber(int sumNum)
        {
            int[] returnValue = new int[] { 0, 0, 0 };

            for (int i = 1; i < sumNum; ++i)
            {
                for (int j = i + 1; j < (sumNum - i); ++j)
                {
                    if (CheckPythagoras(i, j, (sumNum - i - j)))
                    {
                        returnValue[0] = i;
                        returnValue[1] = j;
                        returnValue[2] = (sumNum - i - j);
                    }
                }
            }

            return returnValue;
        }

        private bool CheckPythagoras(int a, int b, int c)
        {
            return (((a * a) + (b * b)) == (c * c));
        }
    }
}