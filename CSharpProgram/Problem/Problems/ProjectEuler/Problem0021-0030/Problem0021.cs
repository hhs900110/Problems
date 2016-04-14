using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0021 : Problem
    {
        public Problem0021() : base(EProblemType.PROJECT_EULER, 21) { }

        public override void Answer()
        {
            long answer = Find(1, 10000);

            PrintAnswer(answer.ToString());
            // 31626
        }

        private long Find(long startNum, long endNum)
        {
            long returnValue = 0;
            List<long> friendNumber = new List<long>(10);

            for ( long i = startNum; i <= endNum; ++i )
            {
                for ( long j = i+1; j <= endNum; ++j )
                {
                    if ( Calculator.IsFriendNumber(i, j) )
                    {
                        if ( friendNumber.Contains(i) == false )
                        {
                            friendNumber.Add(i);
                            returnValue += i;
                        }
                        if ( friendNumber.Contains(j) == false )
                        {
                            friendNumber.Add(j);
                            returnValue += j;
                        }

                        //Console.WriteLine(string.Format("Is Friend Number : {0} . {1} || Sum : {2}", i, j, returnValue));
                    }
                }

                if ( i % 1000 == 0 )
                {
                    //Console.WriteLine(string.Format("Find I : {0} || Sum : {1}", i, returnValue));
                }
            }

            return returnValue;
        }
    }
}