using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0004 : Problem
    {
        public Problem0004() : base(EProblemType.PROJECT_EULER, 4) { }
        
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