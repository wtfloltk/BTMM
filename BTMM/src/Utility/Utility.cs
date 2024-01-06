using System.Diagnostics;
using BTMM.Utility.Logger;

namespace BTMM.Utility;

public static class Utility
{
    public static Stopwatch StartTime(Stopwatch? t = null)
    {
        t ??= new Stopwatch();
        t.Reset();
        t.Start();
        return t;
    }

    public static void StopTime(string info, Stopwatch t)
    {
        t.Stop();
        Log.Debug($"{info}:{(t.ElapsedMilliseconds / 1000f):0.####} s");
    }
}
