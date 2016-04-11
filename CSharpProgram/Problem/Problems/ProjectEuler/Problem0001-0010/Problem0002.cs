using System;

namespace Problem.ProjectEuler
{
    class Problem0002 : Problem
    {
        private readonly string kQuestion = "피보나치 수열의 각 항은 바로 앞의 항 두 개를 더한 것이 됩니다.\n1과 2로 시작하는 경우 이 수열은 아래와 같습니다.\n1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\n짝수이면서 4백만 이하인 모든 항을 더하면 얼마가 됩니까?";

        public Problem0002() : base(2) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

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