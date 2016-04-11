using System;

namespace Problem.ProjectEuler
{
    class Problem0006 : Problem
    {
        private readonly string kQuestion = "1부터 10까지 자연수를 각각 제곱해 더하면 다음과 같습니다 [제곱의 합].\n\t12 + 22 + ... + 102 = 385\n1부터 10을 먼저 더한 다음에 그 결과를 제곱하면 다음과 같습니다 [합의 제곱].\n\t(1 + 2 + ... + 10)2 = 552 = 3025\n따라서 1부터 10까지 자연수에 대해 [합의 제곱]과 [제곱의 합] 의 차이는 3025 - 385 = 2640 이 됩니다.\n그러면 1부터 100까지 자연수에 대해 [합의 제곱]과 [제곱의 합]의 차이는 얼마입니까?";

        public Problem0006() : base(6) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

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