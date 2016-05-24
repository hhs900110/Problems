using System;

namespace CSharpProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton<Data.DBManager>.Instance.DataLoad();

            //Problem.IProblemMain problemMain = new Problem.ProblemManager();

            //problemMain.PrintQuestionAndAnswer();
        }
    }
}