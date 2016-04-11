using System.Collections.Generic;

namespace Problem
{
    class ProblemManager : IProblemMain
    {
        private EProblemType m_problemType = EProblemType.PROJECT_EULER;
        private Dictionary<EProblemType, IProblemMain> m_problemMains = new Dictionary<EProblemType,IProblemMain>(2);

        private IProblemMain ProblemMain
        {
            get
            {
                if (m_problemMains.ContainsKey(m_problemType) == false)
                {
                    switch (m_problemType)
                    {
                        case EProblemType.PROJECT_EULER:
                            m_problemMains.Add(m_problemType, new ProjectEuler.ProjectEulerMain());
                            break;

                        case EProblemType.CODING_DOJANG:
                            m_problemMains.Add(m_problemType, new CodingDojang.CodingDojangMain());
                            break;
                    }
                }
                return m_problemMains[m_problemType];
            }
        }

        public void PrintQuestionAndAnswer()
        {
            ProblemMain.PrintQuestionAndAnswer();
        }

        public void PrintQuestion()
        {
            ProblemMain.PrintQuestion();
        }

        public void PrintAnswer()
        {
            ProblemMain.PrintAnswer();
        }
    }
}