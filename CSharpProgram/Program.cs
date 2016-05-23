using System;

namespace CSharpProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton<Data.DBManager>.Instance.DataLoad();

            Problem.IProblemMain problemMain = new Problem.ProblemManager();

            problemMain.PrintQuestionAndAnswer();

            //Singleton<MongoDBUtil.MongoDBManager>.Instance.ConvertData<Data.Table.SProblemDataUnit>(
            //    "ProjectEuler", Singleton<Data.Table.ProjectEulerDataTable>.Instance.mDicData);
        }
    }
}