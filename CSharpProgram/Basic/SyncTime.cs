/**
 * @file	SyncTime.cs
 * @class	SyncTime
 * @description
 *			서버와 동기화된 시간.
 *			DateTime.Now를 SyncTime.Now로 대체.
 */

using System;

class SyncTime
{
    private static TimeSpan m_eclipsed = new TimeSpan(0);

    //서버와 동기화된 현재 시간.
    public static DateTime Now
    {
        get { return LocalTime + EclipsedTime; }
    }

    public static DateTime Today
    {
        get { return Now.Date; }
    }

    //서버와 로컬의 차이 시간.
    public static TimeSpan EclipsedTime
    {
        get { return m_eclipsed; }
    }

    //로컬 시간
    public static DateTime LocalTime
    {
        get { return DateTime.Now; }
    }

    //서버 시간
    public static DateTime ServerTime
    {
        get { return LocalTime - EclipsedTime; }
        set { m_eclipsed = value - LocalTime; }
    }

    public static string NowString
    {
        get
        {
            DateTime now = Now;
            return now.ToString();
        }
    }
}