using System;
using System.Xml;

namespace Data.Table
{
    public struct SProblemDataUnit : IDataBase
    {
        private int mProblemIndex;
        private string mProblemTitle;
        private string mProblemQuestion;

        public int Index() { return ProblemIndex; }

        public int ProblemIndex { get { return mProblemIndex; } }
        public string ProblemTitle { get { return mProblemTitle; } }
        public string ProblemQuestion { get { return mProblemQuestion; } }

        public void SetData(XmlReader xmlRead)
        {
            XMLSwitcher.TryParse(xmlRead, "ProblemIndex", out mProblemIndex);
            XMLSwitcher.TryParse(xmlRead, "ProblemTitle", out mProblemTitle);
            XMLSwitcher.TryParse(xmlRead, "QuestionDetail", out mProblemQuestion);
        }
    }
}