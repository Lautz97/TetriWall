using UnityEngine;

public static class TimeManager
{
    public static void InitTime()
    {
        Time.timeScale = 1;
    }
    public static void StopTime()
    {
        Time.timeScale = 0;
    }

    public static void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
