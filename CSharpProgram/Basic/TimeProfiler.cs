/**
 * @file	CTimeProfiler.cs
 * @class	CTimeProfiler
 * @description
 *			성능 및 병목 현상이 발생하는 지점을 찾아내기 위한 프로파일러.
 */

using System;
using System.Collections.Generic;

class CTimeProfiler
{
    private class Node
    {
        private DateTime beginTime = new DateTime(0);
        private DateTime endTime = new DateTime(0);
        private TimeSpan eclipsed = TimeSpan.Zero;

        private DateTime restTime;
        private List<double> restTimeStack = new List<double>(2);
        private bool checkRest = false;

        public TimeSpan Eclipsed
        {
            get { return this.eclipsed; }
        }
        public TimeSpan RestEclipsed
        {
            get { return SyncTime.Now - this.beginTime; }
        }
        public bool CheckRest
        {
            get { return this.checkRest; }
        }

        public DateTime Begin()
        {
            this.checkRest = false;
            this.beginTime = SyncTime.Now;
            this.eclipsed = TimeSpan.Zero;
            return this.beginTime;
        }
        public void Rest()
        {
            this.Rest(false);
        }
        private void Rest(bool isEnd)
        {
            if ((isEnd && this.checkRest)
                || (isEnd == false))
            {
                if (restTime.Ticks == 0)
                {
                    restTime = this.beginTime;
                }
                restTimeStack.Add((SyncTime.Now - restTime).TotalMilliseconds);
                restTime = SyncTime.Now;
                this.checkRest = true;
            }
        }
        public double RestAverage()
        {
            double totalRest = 0;
            foreach (double rest in restTimeStack)
            {
                totalRest += rest;
            }
            return totalRest / restTimeStack.Count;
        }
        public DateTime End()
        {
            Rest(true);
            this.endTime = SyncTime.Now;
            this.eclipsed = this.endTime - this.beginTime;
            return this.endTime;
        }
    }

    private static Dictionary<string, Node> m_nodes = new Dictionary<string, Node>();

    public static void Begin(string key)
    {
        if (!m_nodes.ContainsKey(key))
        {
            m_nodes.Add(key, new Node());
        }

        DateTime beginTime = m_nodes[key].Begin();
        //CDefine.DebugLog(string.Format("[Profiler] Begin:{0} at {1}.", key, beginTime));
    }

    public static void Rest(string key, bool viewLog = false)
    {
        if (!m_nodes.ContainsKey(key))
        {
            return;
        }
        m_nodes[key].Rest();
        if (viewLog == true)
        {
            Debugger.Log(string.Format("[Profiler] Rest:{0} at {1} => {2} m/s.", key, SyncTime.Now, m_nodes[key].RestEclipsed.TotalMilliseconds.ToString("#.00")));
        }
    }

    public static void End(string key)
    {
        if (!m_nodes.ContainsKey(key))
        {
            return;
        }

        DateTime endTime = m_nodes[key].End();
        TimeSpan eclipsed = m_nodes[key].Eclipsed;
#if !SERVER && !TOOL
        bool view = false;
        if (view)
        {
            string message ="";
            if (m_nodes[key].CheckRest)
            {
                double rest = m_nodes[key].RestAverage();
                message = string.Format("[Profiler End] [{1}] T [Total {2} m/s] [{3} m/s] {0}", key, endTime, eclipsed.TotalMilliseconds.ToString("00000.00"), rest.ToString("00000.00"));

                if (rest > 10.0f)
                {
                    Debugger.LogWarning(message);
                }
                else
                {
                    Debugger.Log(message);
                }
            }
            else
            {
                message = string.Format("[Profiler End] [{1}] F [Total {2} m/s] {0}", key, endTime, eclipsed.TotalMilliseconds.ToString("00000.00"));

                if (eclipsed.TotalMilliseconds > 10.0f)
                {
                    Debugger.LogWarning(message);
                }
                else
                {
                    Debugger.Log(message);
                }
            }
        }
#else
		bool view = false;
		if ( view )
		{
			CDefine.DebugLog(string.Format("[Profiler] End:{0} at {1}  => TotalTime : {2} m/s", key, endTime, eclipsed.TotalMilliseconds.ToString("#.00")));
		}
#endif
        m_nodes.Remove(key);
    }

    public static string CheckOnThread()
    {
        if (m_nodes.Count > 0)
        {
            string errorFiles = null;
            foreach (KeyValuePair<string, Node> node in m_nodes)
            {
                Debugger.LogError(string.Format("[Profiler] Don't End Thread : {0}", node.Key));
                if (string.IsNullOrEmpty(errorFiles))
                {
                    errorFiles = node.Key;
                }
                else
                {
                    errorFiles += " | " + node.Key;
                }
            }
            Debugger.LogError(errorFiles);
            return errorFiles;
        }
        return "";
    }

    public static bool IsFinishedThread()
    {
        if (m_nodes.Count > 0)
        {
            return false;
        }
        return true;
    }
}