public static class GamePlaySettings
{
    // movement

    public static bool CanMove = false;
    public const bool DEFAULT_onlyHorizontal = true;
    public static bool onlyHorizontal = true;
    //distance from chunks
    public const int DEFAULT_initialChunkDistance = 3;
    public static int initialChunkDistance = 3;
    //
    public const int DEFAULT_deltaChunkDistance = 1;
    public static int deltaChunkDistance = 1;
    // speed and multiplier
    public const float DEFAULT_initialSpeed = 15;
    public static float initialSpeed = 15;
    //
    public const float DEFAULT_initialdeltaSpeed = 0.1f;
    public static float initialdeltaSpeed = 0.1f;
    //
    public const float DEFAULT_initialSpeedMultiplier = 1;
    public static float initialSpeedMultiplier = 1;
    //
    public const float DEFAULT_deltaSpeedMultiplier = 1;
    public static float deltaSpeedMultiplier = 1;
    //score
    public const int DEFAULT_initialPoints = 0;
    public static int initialPoints = 0;
    //
    public const int DEFAULT_pointsXWall = 1;
    public static int pointsXWall = 1;
    //
    public const int DEFAULT_initialScoreMultiplier = 1;
    public static int initialScoreMultiplier = 1;
    //
    public const int DEFAULT_deltaScoreMultiplier = 1;
    public static int deltaScoreMultiplier = 1;


    // clustering
    public const int DEFAULT_initialClusterDimension = 20;
    public static int initialClusterDimension { private set; get; } = 20;


    // tutorial
    public const bool DEFAULT_showTutorial = true;
    public static bool showTutorial = true;

}