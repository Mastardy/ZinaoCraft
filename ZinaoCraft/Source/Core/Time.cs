using System.Diagnostics;

namespace ZinaoCraft;

public static class Time
{
    private static Stopwatch stopWatch = new();
    
    static Time()
    {
        stopWatch.Start();
    }

    public static void UpdateDeltaTime()
    {
        deltaTime = time - lastTime;
        lastTime = time;
    }

    private static float lastTime;
    public static float deltaTime { get; private set; }
    public static float time => (float)stopWatch.Elapsed.TotalSeconds;
    
    
}