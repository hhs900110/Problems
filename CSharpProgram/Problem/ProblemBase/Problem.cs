using System;

namespace Problem
{
    abstract class Problem : IProblem
    {
        private int m_ProblemNum = 0;

        public Problem(int pProblemNum)
        {
            m_ProblemNum = pProblemNum;
        }

        public abstract void Question();
        public abstract void Answer();

        protected void PrintQuestion(string pQuestion)
        {
            Console.WriteLine(string.Format("No.{0} Q]\n\n{1}\n", m_ProblemNum.ToString("0000"), pQuestion));
        }

        protected void PrintQuestion(string[] pQuestion)
        {
            string question = "";

            for (int i = 0; i < pQuestion.Length; ++i)
            {
                if (i == 0)
                {
                    question += pQuestion[i];
                }
                else
                {
                    question += "\n" + pQuestion[i];
                }
            }
            PrintQuestion(question);
        }

        protected void PrintAnswer(string pAnswer)
        {
            Console.WriteLine(string.Format("No.{0} A] {1}\n", m_ProblemNum.ToString("0000"), pAnswer));
        }
    }
}


//class Problem0000 : Problem
//{
//    public Problem0000() : base(0) { }

//    /*
//     */

//    public override void Answer()
//    {
//        int answer = 0;

//        PrintAnswer(answer.ToString());
//    }
//}