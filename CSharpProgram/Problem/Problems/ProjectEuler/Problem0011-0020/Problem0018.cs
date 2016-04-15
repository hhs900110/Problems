using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0018 : Problem
    {
        public Problem0018() : base(EProblemType.PROJECT_EULER, 18) { }

        #region Data
        private readonly string[] kData = new string[]{
                                        "75",
                                      "95  64",
                                    "17  47  82",
                                  "18  35  87  10",
                                "20  04  82  47  65",
                              "19  01  23  75  03  34",
                            "88  02  77  73  07  63  67",
                          "99  65  04  28  06  16  70  92",
                        "41  41  26  56  83  40  80  70  33",
                      "41  48  72  33  47  32  37  16  94  29",
                    "53  71  44  65  25  43  91  52  97  51  14",
                  "70  11  33  28  77  73  17  78  39  68  17  57",
                "91  71  52  38  17  14  91  43  58  50  27  29  48",
              "63  66  04  68  89  53  67  30  73  16  69  87  40  31",
            "04  62  98  27  23  09  70  98  73  93  38  53  60  04  23"
        };
        #endregion

        private List<List<int>> mDataList;

        public override void Answer()
        {
            MakeDataList();

            int answer = FindUpSum();

            PrintAnswer(answer.ToString());
        }

        private void MakeDataList()
        {
            mDataList = new List<List<int>>(2);

            for (int i = 0; i < kData.Length; ++i)
            {
                string[] arrData = kData[i].Split(' ');
                List<int> inListData = new List<int>((int)arrData.Length/2);

                for (int j = 0; j < arrData.Length; ++j)
                {
                    if (string.IsNullOrWhiteSpace(arrData[j]) == false)
                    {
                        int data = 0;

                        if (int.TryParse(arrData[j], out data))
                        {
                            inListData.Add(data);
                        }
                    }
                }
                mDataList.Add(inListData);
            }
        }

        private int FindDownSum()
        {
            // 탐색을 하며 더한 값을 저장할 리스트
            List<List<int>> sum = new List<List<int>>(mDataList.Count);

            for (int i = 0; i < mDataList.Count; ++i)
            {
                sum.Add(new List<int>(mDataList[i].Count));

                if (i == 0)
                {
                    sum[i].Add(mDataList[i][0]);
                }
                else
                {
                    for (int j = 0; j < mDataList[i].Count; ++j)
                    {
                        if (j == 0)
                        {
                            // (i,0) 까지의 합. = (i,0) + (i-1,0) 까지의 합.
                            sum[i].Add(sum[i - 1][j] + mDataList[i][j]);
                        }
                        else if (j == mDataList[i].Count - 1)
                        {
                            // (i,i) 까지의 합. = (i,i) + (i-1,i-1) 까지의 합.
                            sum[i].Add(sum[i - 1][j - 1] + mDataList[i][j]);
                        }
                        else
                        {
                            // (i,j) 까지의 합. = (i,j) + Max((i-1,j-1) 까지의 합, (i-1,j) 까지의 합)
                            sum[i].Add(mDataList[i][j] + Math.Max(sum[i - 1][j - 1], sum[i - 1][j]));
                        }
                    }
                }
            }

            int max = 0;

            for (int i = 0; i < sum[sum.Count - 1].Count; ++i)
            {
                max = Math.Max(max, sum[sum.Count - 1][i]);
            }
            return max;
        }

        private int FindUpSum()
        {
            TriTree tree = new TriTree();
            tree.SetData(mDataList);

            return tree.SumMaxValue();
        }
    }
}