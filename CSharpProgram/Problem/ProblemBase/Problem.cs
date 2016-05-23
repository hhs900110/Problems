using System;

namespace Problem
{
    abstract class Problem : IProblem
    {
        private EProblemType mProblemType;
        private int mProblemNum = 0;

        public Problem(EProblemType type, int pProblemNum)
        {
            mProblemType = type;
            mProblemNum = pProblemNum;
        }

        public void Question()
        {
            Data.Unit.ProjectEulerDBUnit dataUnit = new Data.Unit.ProjectEulerDBUnit();

            switch ( mProblemType )
            {
                case EProblemType.PROJECT_EULER:

                    dataUnit = Singleton<MongoDBUtil.MongoDBManager>.Instance.ProjectEulerDB.GetDataByIndex(mProblemNum);
                    break;
            }

            Console.WriteLine(string.Format("No.{0} Q] {1}\n\n{2}\n", dataUnit.index.ToString("0000"), dataUnit.title, dataUnit.question));
        }

        public abstract void Answer();
        
        protected void PrintAnswer(string pAnswer)
        {
            Console.WriteLine(string.Format("No.{0} A] {1}\n", mProblemNum.ToString("0000"), pAnswer));
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