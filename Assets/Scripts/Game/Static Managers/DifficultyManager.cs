public static class DifficultyManager
{
    public static void Initialize()
    {
        GamePlayCounters.actualSpeedMultiplier = GamePlaySettings.initialSpeedMultiplier;
        GamePlayCounters.actualSpeed = GamePlaySettings.initialSpeed;
        GamePlayCounters.actualChunkDistance = GamePlaySettings.initialChunkDistance;
        GamePlayCounters.actualDeltaSpeed = GamePlaySettings.initialdeltaSpeed;
        GamePlaySettings.onlyHorizontal = true;
    }

    public static void EnableVerticalMovement()
    {
        GamePlaySettings.onlyHorizontal = false;
    }

    public static void IncreaseActualSpeed()
    {
        GamePlayCounters.actualSpeed += GamePlayCounters.actualDeltaSpeed;
    }

    public static void DecreaseActualSpeed()
    {
        GamePlayCounters.actualSpeed -= GamePlayCounters.actualDeltaSpeed;
    }

    public static void IncreaseActualSpeedMultiplier()
    {
        GamePlayCounters.actualSpeedMultiplier += GamePlaySettings.deltaSpeedMultiplier;
    }

    public static void DecreaseActualSpeedMultiplier()
    {
        GamePlayCounters.actualSpeedMultiplier -= GamePlaySettings.deltaSpeedMultiplier;
    }

    public static void IncreaseDeltaSpeedMultiplier()
    {
        GamePlayCounters.actualDeltaSpeed *= 2;
    }

    public static void DecreaseDeltaSpeedMultiplier()
    {
        GamePlayCounters.actualDeltaSpeed /= 2;
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