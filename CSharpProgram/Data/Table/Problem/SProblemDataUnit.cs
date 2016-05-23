using System;
using System.Xml;

namespace Data.Table
{
    public class SProblemDataUnit : IDataBase
    {
        public int Index() { return index; }
        public string ProblemTitle() { return title; }
        public string ProblemQuestion() { return question; }

        public int index { get; set; }
        public string title { get; set; }
        public string question { get; set; }

        public void SetData(XmlReader xmlRead)
        {
            int mProblemIndex;
            string mProblemTitle;
            string mProblemQuestion;
            XMLSwitcher.TryParse(xmlRead, "ProblemIndex", out mProblemIndex);
            XMLSwitcher.TryParse(xmlRead, "ProblemTitle", out mProblemTitle);
            XMLSwitcher.TryParse(xmlRead, "QuestionDetail", out mProblemQuestion);

            index = mProblemIndex;
            title = mProblemTitle;
            question = mProblemQuestion;
        }
    }
}