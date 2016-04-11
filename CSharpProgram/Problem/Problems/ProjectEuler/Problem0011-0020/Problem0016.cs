using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0016 : Problem
    {
        private readonly string kQuestion = "215 = 32768 의 각 자리수를 더하면 3 + 2 + 7 + 6 + 8 = 26 입니다.\n21000의 각 자리수를 모두 더하면 얼마입니까?";

        public Problem0016() : base(16) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            int answer = 0;

            PrintAnswer(answer.ToString());
        }
    }
}