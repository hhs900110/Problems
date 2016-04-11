using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0014 : Problem
    {
        private readonly string[] kQuestion = new string[] {
            "양의 정수 n에 대하여, 다음과 같은 계산 과정을 반복하기로 합니다.",
            "\tn → n / 2 (n이 짝수일 때)","\tn → 3 n + 1 (n이 홀수일 때)",
            "13에 대하여 위의 규칙을 적용해보면 아래처럼 10번의 과정을 통해 1이 됩니다.",
            "\t13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1",
            "아직 증명은 되지 않았지만, 이런 과정을 거치면 어떤 수로 시작해도 마지막에는 1로 끝나리라 생각됩니다. ",
            "(역주: 이것은 콜라츠 추측 Collatz Conjecture이라고 하며, 이런 수들을 우박수 hailstone sequence라 부르기도 합니다)",
            "그러면, 백만(1,000,000) 이하의 수로 시작했을 때 1까지 도달하는데 가장 긴 과정을 거치는 숫자는 얼마입니까?",
            "참고: 계산 과정 도중에는 숫자가 백만을 넘어가도 괜찮습니다." };

        public Problem0014() : base(14) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

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
