using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    public class ProjectEulerMain : ProblemMain
    {
        protected override List<IProblem> GetProblemList()
        {
            List<IProblem> problem = new List<IProblem>(2);

            problem.Add(new Problem0001());

            return problem;
        }
    }
}
