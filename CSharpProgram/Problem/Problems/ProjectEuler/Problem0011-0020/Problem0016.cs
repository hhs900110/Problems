using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0016 : Problem
    {
        public Problem0016() : base(EProblemType.PROJECT_EULER, 16) { }
        
        public override void Answer()
        {
            ulong answer = Find(2, 1000);

            PrintAnswer(answer.ToString());
        }

        private ulong Find(uint targetNum, ulong squareNum)
        {
            ulong returnValue = 0;

            List<byte> powList = new List<byte>(2);

            powList.Add(1);

            byte overNum = 0;
            for (ulong i = 0; i < squareNum; ++i)
            {
                for (int j = 0; j < powList.Count; ++j)
                {
                    uint setNum = powList[j] * targetNum + overNum;
                    overNum = 0;

                    if (setNum >= 10)
                    {
                        if (powList.Count <= j + 1)
                        {
                            powList.Add(0);
                        }

                        overNum = (byte)(setNum / 10);
                        setNum %= 10;
                    }

                    powList[j] = (byte)setNum;
                }
            }

            for (int i = 0; i < powList.Count; ++i)
                returnValue += powList[i];

            return returnValue;
        }
    }
}