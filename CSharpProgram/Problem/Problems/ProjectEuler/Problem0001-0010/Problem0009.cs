using System;

namespace Problem.ProjectEuler
{
    class Problem0009 : Problem
    {
        private readonly string kQuestion = "세 자연수 a, b, c 가 피타고라스 정리 a^2 + b^2 = c^2 를 만족하면 피타고라스 수라고 부릅니다 (여기서 a < b < c ).\n예를 들면 32 + 42 = 9 + 16 = 25 = 52이므로 3, 4, 5는 피타고라스 수입니다.\na + b + c = 1000 인 피타고라스 수 a, b, c는 한 가지 뿐입니다.\n이 때, a × b × c 는 얼마입니까?";

        public Problem0009() : base(9) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

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