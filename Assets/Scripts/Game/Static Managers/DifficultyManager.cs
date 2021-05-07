public static class DifficultyManager
{
    public static void Initialize()
    {
        GamePlayCounters.actualSpeedMultiplier = GamePlaySettings.initialSpeedMultiplier;
        GamePlayCounters.actualSpeed = GamePlaySettings.initialSpeed;
        GamePlayCounters.actualChunkDistance = GamePlaySettings.initialChunkDistance;
        GamePlaySettings.onlyHorizontal = true;
    }

    public static void EnableVerticalMovement()
    {
        GamePlaySettings.onlyHorizontal = false;
    }

    public static void IncreaseActualSpeed()
    {
        GamePlayCounters.actualSpeed += GamePlaySettings.deltaSpeed;
    }

    public static void DecreaseActualSpeed()
    {
        GamePlayCounters.actualSpeed -= GamePlaySettings.deltaSpeed;
    }

    public static void IncreaseActualSpeedMultiplier()
    {
        GamePlayCounters.actualSpeedMultiplier += GamePlaySettings.deltaSpeedMultiplier;
    }

    public static void DecreaseActualSpeedMultiplier()
    {
        GamePlayCounters.actualSpeedMultiplier -= GamePlaySettings.deltaSpeedMultiplier;
    }

    public static void IncreaseChunkDistance()
    {
        GamePlayCounters.actualChunkDistance += GamePlaySettings.deltaChunkDistance;
    }

    public static void DecreaseChunkDistance()
    {
        GamePlayCounters.actualChunkDistance -= GamePlaySettings.deltaChunkDistance;
    }

}