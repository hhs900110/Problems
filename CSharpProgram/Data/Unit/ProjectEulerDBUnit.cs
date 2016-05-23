using System;
using System.Xml;
using MongoDB.Bson;

namespace Data.Unit
{
    class ProjectEulerDBUnit : IDBUnitBase
    {
        public ObjectId _id { get; set; }
        public int index { get; set; }
        public string title { get; set; }
        public string question { get; set; }

        public int Index()
        {
            return index;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", index, title, question);
        }

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