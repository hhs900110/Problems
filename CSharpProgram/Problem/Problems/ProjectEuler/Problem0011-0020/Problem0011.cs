using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.ProjectEuler
{
    class Problem0011 : Problem
    {
        private readonly string kQuestion = "아래와 같은 20×20 격자가 있습니다.\n\t08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08\n\t49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00\n\t81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65\n\t52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91\n\t22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80\n\t24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50\n\t32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70\n\t67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21\n\t24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72\n\t21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95\n\t78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92\n\t16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57\n\t86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58\n\t19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40\n\t04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66\n\t88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69\n\t04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36\n\t20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16\n\t20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54\n\t01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48\n위에서 대각선 방향으로 연속된 붉은 숫자 네 개의 곱은 26 × 63 × 78 × 14 = 1788696 입니다.\n그러면 수평, 수직, 또는 대각선 방향으로 연속된 숫자 네 개의 곱 중 최대값은 얼마입니까?";

        public Problem0011() : base(11) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            long answer = 0;

            int[,] intArray = new int[,] { {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},   // 0
                                           {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43 ,69 ,48 ,04 ,56 ,62 ,00},   // 1
                                           {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88 ,30 ,03 ,49 ,13 ,36 ,65},   // 2
                                           {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32 ,56 ,71 ,37 ,02 ,36 ,91},   // 3
                                           {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40 ,40 ,28 ,66 ,33 ,13 ,80},   // 4
                                           {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36 ,84 ,20 ,35 ,17 ,12 ,50},   // 5
                                           {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54 ,70 ,66 ,18 ,38 ,64 ,70},   // 6
                                           {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08 ,40 ,91 ,66 ,49 ,94 ,21},   // 7
                                           {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83 ,14 ,88 ,34 ,89 ,63 ,72},   // 8
                                           {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61 ,33 ,97 ,34 ,31 ,33 ,95},   // 9
                                           {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62 ,16 ,14 ,09 ,53 ,56 ,92},   //10
                                           {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17 ,54 ,24 ,36 ,29 ,85 ,57},   //11
                                           {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60 ,21 ,58 ,51 ,54 ,17 ,58},   //12
                                           {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52 ,17 ,77 ,04 ,89 ,55 ,40},   //13
                                           {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26 ,26 ,79 ,33 ,27 ,98 ,66},   //14
                                           {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55 ,12 ,32 ,63 ,93 ,53 ,69},   //15
                                           {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46 ,29 ,32 ,40 ,62 ,76 ,36},   //16
                                           {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67 ,59 ,85 ,74 ,04 ,36 ,16},   //17
                                           {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86 ,81 ,16 ,23 ,57 ,05 ,54},   //18
                                           {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43 ,52 ,01 ,89 ,19 ,67 ,48} }; //19

            answer = FindMaxMultifly(intArray, 4);

            PrintAnswer(answer.ToString());
        }

        private long FindMaxMultifly(int[,] intArray, int useAmount)
        {
            long returnValue = long.MinValue;

            int firstLength = intArray.GetLength(0);
            int secondLength = intArray.GetLength(1);

            for (int i = 0; i < firstLength; ++i)
            {
                for (int j = 0; j < secondLength; ++j)
                {
                    returnValue = Math.Max(returnValue, Multifly_Width(intArray, useAmount, i, j));
                    returnValue = Math.Max(returnValue, Multifly_Height(intArray, useAmount, i, j));
                    returnValue = Math.Max(returnValue, Multifly_IncreaseDiagonal(intArray, useAmount, i, j));
                    returnValue = Math.Max(returnValue, Multifly_DecreaseDiagonal(intArray, useAmount, i, j));
                }
            }

            return returnValue;
        }

        private long Multifly_Width(int[,] intArray, int useAmount, int startX, int startY)
        {
            long returnValue = long.MinValue;

            int firstLength = intArray.GetLength(0);
            int secondLength = intArray.GetLength(1);

            if (firstLength > (startX))
            {
                if (secondLength > (startY + useAmount))
                {
                    returnValue = 1;
                    for (int i = 0; i < useAmount; ++i)
                    {
                        int MulValue = intArray[startX, startY + i];
                        returnValue *= MulValue;
                    }
                }
            }

            return returnValue;
        }

        private long Multifly_Height(int[,] intArray, int useAmount, int startX, int startY)
        {
            long returnValue = long.MinValue;

            int firstLength = intArray.GetLength(0);
            int secondLength = intArray.GetLength(1);

            if (firstLength > (startX + useAmount))
            {
                if (secondLength > (startY))
                {
                    returnValue = 1;
                    for (int i = 0; i < useAmount; ++i)
                    {
                        int MulValue = intArray[startX + i, startY];
                        returnValue *= MulValue;
                    }
                }
            }

            return returnValue;
        }

        private long Multifly_IncreaseDiagonal(int[,] intArray, int useAmount, int startX, int startY)
        {
            long returnValue = long.MinValue;

            int firstLength = intArray.GetLength(0);
            int secondLength = intArray.GetLength(1);

            if (firstLength > (startX + useAmount))
            {
                if (secondLength > (startY + useAmount))
                {
                    returnValue = 1;
                    for (int i = 0; i < useAmount; ++i)
                    {
                        int MulValue = intArray[startX + i, startY + i];
                        returnValue *= MulValue;
                    }
                }
            }

            return returnValue;
        }

        private long Multifly_DecreaseDiagonal(int[,] intArray, int useAmount, int startX, int startY)
        {
            long returnValue = long.MinValue;

            int firstLength = intArray.GetLength(0);
            int secondLength = intArray.GetLength(1);

            if (firstLength > (startX) && startX >= useAmount)
            {
                if (secondLength > (startY + useAmount))
                {
                    returnValue = 1;
                    for (int i = 0; i < useAmount; ++i)
                    {
                        int MulValue = intArray[startX - i, startY + i];
                        returnValue *= MulValue;
                    }
                }
            }

            return returnValue;
        }
    }
}