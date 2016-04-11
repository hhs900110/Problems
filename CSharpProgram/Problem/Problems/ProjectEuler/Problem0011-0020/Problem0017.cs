using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0017 : Problem
    {
        private readonly string[] kQuestion = new string[] {
            "1부터 5까지의 숫자를 영어로 쓰면 one, two, three, four, five 이고,",
            "각 단어의 길이를 더하면 3 + 3 + 5 + 4 + 4 = 19 이므로 사용된 글자는 모두 19개입니다.",
            "",
            "1부터 1,000까지 영어로 썼을 때는 모두 몇 개의 글자를 사용해야 할까요?",
            "",
            "참고: 빈 칸이나 하이픈('-')은 셈에서 제외하며, 단어 사이의 and 는 셈에 넣습니다.",
            "예를 들어 342를 영어로 쓰면 three hundred and forty-two 가 되어서 23 글자,",
            "115 = one hundred and fifteen 의 경우에는 20 글자가 됩니다." };

        private Dictionary<ulong, string> m_dicSpelling;

        public Problem0017() : base(17) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            ulong answer = Find(1, 1000);

            PrintAnswer(answer.ToString());
        }

        private void SetSpelling()
        {
            if ( m_dicSpelling == null )
            {
                m_dicSpelling = new Dictionary<ulong, string>(10);

                m_dicSpelling.Add(1, "one");
                m_dicSpelling.Add(2, "two");
                m_dicSpelling.Add(3, "three");
                m_dicSpelling.Add(4, "four");
                m_dicSpelling.Add(5, "five");
                m_dicSpelling.Add(6, "six");
                m_dicSpelling.Add(7, "seven");
                m_dicSpelling.Add(8, "eight");
                m_dicSpelling.Add(9, "nine");
                m_dicSpelling.Add(10, "ten");
                m_dicSpelling.Add(11, "eleven");
                m_dicSpelling.Add(12, "twelve");
                m_dicSpelling.Add(13, "thirteen");
                m_dicSpelling.Add(14, "fourteen");
                m_dicSpelling.Add(15, "fifteen");
                m_dicSpelling.Add(16, "sixteen");
                m_dicSpelling.Add(17, "seventeen");
                m_dicSpelling.Add(18, "eighteen");
                m_dicSpelling.Add(19, "nineteen");
                m_dicSpelling.Add(20, "twenty");
                m_dicSpelling.Add(30, "thirty");
                m_dicSpelling.Add(40, "forty");
                m_dicSpelling.Add(50, "fifty");
                m_dicSpelling.Add(60, "sixty");
                m_dicSpelling.Add(70, "seventy");
                m_dicSpelling.Add(80, "eighty");
                m_dicSpelling.Add(90, "ninety");
                m_dicSpelling.Add(100, "hundred");
                m_dicSpelling.Add(1000, "thousand");
                // 10,000 = ten thousand
                // 100,000 = a hundred thousand
                m_dicSpelling.Add(1000000, "million");
                // 10,000,000 = ten million
                // 100,000,000 = one hundred million
                m_dicSpelling.Add(1000000000, "billion");
                // 10,000,000,000 = ten billion
                // 100,000,000,000 = a hundred billion
                m_dicSpelling.Add(1000000000000, "trillion");
                // 10,000,000,000,000 = ten trillion
                // 100,000,000,000,000 = a hundred trillion
                m_dicSpelling.Add(1000000000000000, "quadrillion");
            }
        }

        private ulong Find(ulong minNumber, ulong maxNumber)
        {
            ulong returnValue = 0;

            for ( ulong i = minNumber; i <= maxNumber; ++i )
            {
                string spelling = GetSpelling(i);

                string[] arrSpelling = spelling.Split(' ');

                int count = 0;
                for ( int j = 0; j < arrSpelling.Length; ++j )
                {
                    count += arrSpelling[j].Length;
                }
                returnValue = returnValue + (ulong) count;

                //System.Console.WriteLine(string.Format("{0} : {1}\t{2}", i, spelling, count));
            }

            return returnValue;
        }

        private string GetSpelling(ulong targetNumber)
        {
            SetSpelling();

            string returnValue = "";

            List<ulong> thousandSplit = new List<ulong>();
            ulong splitNumber = targetNumber;

            Unit.DivisionUnit divition = new Unit.DivisionUnit();

            while ( splitNumber != 0 )
            {
                divition.SetDivisionUnit(splitNumber, 1000);

                thousandSplit.Add(divition.Remainder);
                splitNumber = divition.Quotien;
            }

            for ( int i = 0; i < thousandSplit.Count; ++i )
            {
                string addString = "";
                ulong tenNumber = 0;

                if ( thousandSplit[i] >= 100 )
                {
                    divition.SetDivisionUnit(thousandSplit[i], 100);

                    if ( m_dicSpelling.ContainsKey(divition.Quotien) )
                    {
                        addString += string.Format("{0} {1}", m_dicSpelling[divition.Quotien], m_dicSpelling[100]);
                    }

                    tenNumber = divition.Remainder;

                    if ( divition.Remainder > 0 )
                    {
                        addString += " and";
                    }
                }
                else
                {
                    tenNumber = thousandSplit[i];
                }

                if ( m_dicSpelling.ContainsKey(tenNumber) ) // 이곳에 걸리면 특수 넘버 (1~20, 10의 배수의 숫자)
                {
                    if ( thousandSplit[i] > 100 )
                        addString += string.Format(" {0}", m_dicSpelling[tenNumber]);
                    else
                        addString += m_dicSpelling[tenNumber];
                }
                else
                {
                    // 10의 자리수와 1의 자리수 따로따로 이어준다.
                    divition.SetDivisionUnit(tenNumber, 10);

                    if ( divition.Quotien > 0 )
                    {
                        if ( thousandSplit[i] > 100 )
                            addString += string.Format(" {0}", m_dicSpelling[divition.Quotien * 10]);
                        else
                            addString += string.Format("{0}", m_dicSpelling[divition.Quotien * 10]);
                    }
                    if ( divition.Remainder > 0 )
                    {
                        if ( thousandSplit[i] > 10 )
                            addString += string.Format(" {0}", m_dicSpelling[divition.Remainder]);
                        else
                            addString += string.Format("{0}", m_dicSpelling[divition.Remainder]);
                    }
                }

                if ( m_dicSpelling.ContainsKey((ulong) (i * 1000)) )
                {
                    if ( string.IsNullOrWhiteSpace(returnValue) == false)
                        addString += string.Format(" {0} and", m_dicSpelling[(ulong) (i * 1000)]);
                    else
                        addString += string.Format(" {0}", m_dicSpelling[(ulong) (i * 1000)]);
                }
                returnValue = string.Format("{0} {1}", addString, returnValue);
            }

            return returnValue;
        }
    }
}