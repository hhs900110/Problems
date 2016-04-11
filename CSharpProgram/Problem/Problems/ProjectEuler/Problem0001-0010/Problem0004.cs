using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0004 : Problem
    {
        private readonly string[] kQuestion = new string[] {
            "앞에서부터 읽을 때나 뒤에서부터 읽을 때나 모양이 같은 수를 대칭수(palindrome)라고 부릅니다.",
            "두 자리 수를 곱해 만들 수 있는 대칭수 중 가장 큰 수는 9009 (= 91 × 99) 입니다.",
            "세 자리 수를 곱해 만들 수 있는 가장 큰 대칭수는 얼마입니까?" };

        public Problem0004() : base(4) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            int answer = 0;

            List<int> pList = FindMultiplePalindrome(100, 999);
            answer = Calculator.Max(pList);

            PrintAnswer(answer.ToString());
        }

        private List<int> FindMultiplePalindrome(int min, int max)
        {
            List<int> pList = new List<int>(10);

            for (int i = max; i >= min; --i)
            {
                for (int j = max; j >= min; --j)
                {
                    if (IsPalindrome(i * j))
                    {
                        pList.Add(i * j);
                    }
                }
            }

            return pList;
        }

        private bool IsPalindrome(int pNumber)
        {
            bool isPalindrome = true;

            string strNum = pNumber.ToString();   // 문자열로 변환
            char[] chrNum = strNum.ToCharArray(); // 변환한 문자열을 자릿수별로 나눠가진다 (비교를 위해!)

            for (int i = 0; i < chrNum.Length / 2; ++i)
            {
                if (chrNum[i] != chrNum[chrNum.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }
    }
}