using System;
using System.Collections.Generic;

class TriTree
{
    public class TriTreeNode
    {
        private uint mPosLine;
        private uint mPosRow;

        private int mValue;
        private TriTreeNode mLeftChild;
        private TriTreeNode mRightChild;

        private int mMaxValue = int.MinValue;
        private int mMinValue = int.MaxValue;

        public TriTreeNode(uint pLine, uint pRow, int pValue)
        {
            mPosLine = pLine;
            mPosRow = pRow;
            mValue = pValue;
            mLeftChild = null;
            mRightChild = null;
        }

        public TriTreeNode(uint pLine, uint pRow, int pValue, TriTreeNode pLeftChild, TriTreeNode pRightChild)
        {
            mPosLine = pLine;
            mPosRow = pRow;
            mValue = pValue;
            mLeftChild = pLeftChild;
            mRightChild = pRightChild;
        }

        public void SetLeftChild(TriTreeNode pLeftChild)
        {
            mLeftChild = pLeftChild;
        }

        public void SetRightChild(TriTreeNode pRightChild)
        {
            mRightChild = pRightChild;
        }

        public int SumMaxValue()
        {
            if (mMaxValue == int.MinValue)
            {
                if (mLeftChild != null && mRightChild != null)
                    mMaxValue = mValue + Math.Max(mLeftChild.SumMaxValue(), mRightChild.SumMaxValue());
                else if (mLeftChild != null)
                    mMaxValue = mValue + mLeftChild.SumMaxValue();
                else if (mRightChild != null)
                    mMaxValue = mValue + mRightChild.SumMaxValue();
                else
                    mMaxValue = mValue;
            }
            return mMaxValue;
        }

        public int SumMinValue()
        {
            if (mMinValue == int.MaxValue)
            {
                if (mLeftChild != null && mRightChild != null)
                    mMinValue = mValue + Math.Min(mLeftChild.SumMinValue(), mRightChild.SumMinValue());
                else if (mLeftChild != null)
                    mMinValue = mValue + mLeftChild.SumMinValue();
                else if (mRightChild != null)
                    mMinValue = mValue + mRightChild.SumMinValue();
                else
                    mMinValue = mValue;
            }
            return mMinValue;
        }

        public void Delete()
        {
            if (mLeftChild != null)
                mLeftChild.Delete();
            if (mRightChild != null)
                mRightChild.Delete();

            mValue = 0;
            mLeftChild = null;
            mRightChild = null;
        }

        public TriTreeNode FindNode(uint pLine, uint pRow)
        {
            if (mPosLine == pLine && mPosRow == pRow)
            {
                return this;
            }
            if (pLine > mPosLine)
            {
                if (pRow > mPosRow)
                    return mRightChild.FindNode(pLine, pRow);
                else
                    return mLeftChild.FindNode(pLine, pRow);
            }

            return null;
        }
    }

    private TriTreeNode mRoot;

    public void SetData(List<List<int>> pDataList)
    {
        if (mRoot != null)
            mRoot.Delete();

        List<TriTreeNode> lineNodeList = new List<TriTreeNode>(2);
        List<TriTreeNode> lineNodeChildList = new List<TriTreeNode>(2);

        for (int i = pDataList.Count-1; i >= 0; --i)
        {
            lineNodeList.Clear();

            // 맨 아래부터 데이터를 만들어준다.
            for (int j = 0; j < pDataList[i].Count; ++j)
            {
                lineNodeList.Add(new TriTreeNode((uint)i, (uint)j, pDataList[i][j]));
            }

            // 아래 리스트의 데이터를 상위 리스트의 데이터의 자식으로 넣어준다.
            for (int j = 0; j < lineNodeList.Count && j < lineNodeChildList.Count; ++j)
            {
                lineNodeList[j].SetLeftChild(lineNodeChildList[j]);
                lineNodeList[j].SetRightChild(lineNodeChildList[j + 1]);
            }

            // 리스트 복사
            lineNodeChildList.Clear();
            for (int j = 0; j < lineNodeList.Count; ++j)
            {
                lineNodeChildList.Add(lineNodeList[j]);
            }
        }

        if (lineNodeList.Count != 1)
        {
            Console.WriteLine("Wrong Data Setting !!");
        }

        mRoot = lineNodeList[0];
    }

    public int SumMaxValue()
    {
        return mRoot.SumMaxValue();
    }

    public int SumMinValue()
    {
        return mRoot.SumMinValue();
    }
}