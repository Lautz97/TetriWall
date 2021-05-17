public static class InputSettings
{
    //
    public const float DEFAULT_maxTapDistance_continuous = 0.5f;
    public const float DEFAULT_maxTapDistance_discrete = 5f;
    public static float maxTapDistance = 0.5f;

    //
    public const float DEFAULT_minSwipeDistance_continuous = 50f;
    public const float DEFAULT_minSwipeDistance_discrete = 50f;
    public static float minSwipeDistance = 50f;

    //
    public const float DEFAULT_maxTapTime_continuous = 0.125f;
    public const float DEFAULT_maxTapTime_discrete = 0.5f;
    public static float maxTapTime = 0.125f;

    //
    public const float DEFAULT_maxSwipeTime_continuous = 60f;
    public const float DEFAULT_maxSwipeTime_discrete = 2f;
    public static float maxSwipeTime = 60f;

    //
    public const bool DEFAULT_detectOnlyAfterRelease = false;
    public static bool discreteInputCheck = false;
}