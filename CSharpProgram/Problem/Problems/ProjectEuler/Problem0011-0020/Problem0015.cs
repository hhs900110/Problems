using System;
using System.Collections.Generic;

namespace Problem.ProjectEuler
{
    class Problem0015 : Problem
    {
        public Problem0015() : base(EProblemType.PROJECT_EULER, 15) { }
        
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
