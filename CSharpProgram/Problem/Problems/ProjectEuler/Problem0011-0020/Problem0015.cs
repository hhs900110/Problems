using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0015 : Problem
    {
        private readonly string kQuestion = "2 × 2 격자의 왼쪽 위 모서리에서 출발하여 오른쪽 아래 모서리까지 도달하는 길은 모두 6가지가 있습니다 (거슬러 가지는 않기로 합니다).\n그러면 20 × 20 격자에는 모두 몇 개의 경로가 있습니까?";

        public Problem0015() : base(15) { }

        public override void Question()
        {
            PrintQuestion(kQuestion);
        }

        public override void Answer()
        {
            ulong answer = FindRouteCount(20, 20);

            PrintAnswer(answer.ToString());
        }

        private ulong FindRouteCount(int width, int height)
        {
            ulong routeCount = 0;

            ulong[,] route = new ulong[width + 1, height + 1];

            for (int i = 0; i <= width; ++i)
            {
                for (int j = 0; j <= height; ++j)
                {
                    if (i.Equals(0) || j.Equals(0)) // x 혹은 y 좌표가 벽에 붙어있을 때
                    {
                        route[i, j] = 1;
                    }
                    else
                    {
                        route[i, j] = route[i - 1, j] + route[i, j - 1];
                    }
                }
            }

            routeCount = route[width, height];

            return routeCount;
        }
    }
}
