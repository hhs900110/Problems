using System.Collections.Generic;

namespace Problem
{
    public abstract class ProblemMain : IProblemMain
    {
        protected abstract List<IProblem> GetProblemList();

        public void PrintQuestionAndAnswer()
        {
            List<IProblem> problem = GetProblemList();

            for (int i = 0; i < problem.Count; ++i)
            {
                problem[i].Question();
                problem[i].Answer();
            }
        }

        public void PrintQuestion()
        {
            List<IProblem> problem = GetProblemList();

            for (int i = 0; i < problem.Count; ++i)
            {
                problem[i].Question();
            }
        }

        public void PrintAnswer()
        {
            List<IProblem> problem = GetProblemList();

            for (int i = 0; i < problem.Count; ++i)
            {
                problem[i].Answer();
            }
        }
    }
}