using System;
using System.Collections.Generic;

namespace CSharpProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem.IProblemMain problemMain = new Problem.ProblemManager();

            problemMain.PrintQuestionAndAnswer();
        }
    }
}