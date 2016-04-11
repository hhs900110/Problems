using System;

namespace Problem.ProjectEuler
{
    class Problem0006 : Problem
    {
        public Problem0006() : base(EProblemType.PROJECT_EULER, 6) { }
        
        public override void Answer()
        {
            int answer = 0;

            answer = Math.Abs(SquareOfSum(1, 100, 2) - SumOfSquare(100, 2));

            PrintAnswer(answer.ToString());
        }

        private int SquareOfSum(int minRange, int maxRange, int squareNum)
        {
            int returnValue = 1;
            int sumValue = 0;

            for (int i = minRange; i <= maxRange; ++i)
            {
                sumValue += i;
            }

            for (int i = 0; i < squareNum; ++i)
            {
                returnValue *= sumValue;
            }

            return returnValue;
        }

        private int SumOfSquare(int minRange, int maxRange, int squareNum)
        {
            int returnValue = 0;

            for (int i = minRange; i <= maxRange; ++i)
            {
                int square = 1;
                for (int j = 0; j < squareNum; ++j)
                {
                    square *= i;
                }
                returnValue += square;
            }

            return returnValue;
        }

        private int SumOfSquare(int maxRange, int squareNum)
        {
            return SumOfSquare(1, maxRange, squareNum);
        }
    }
}