public static class GamePlaySettings
{
    // movement
    public static bool onlyHorizontal = true;
    //distance from chunks
    public static int initialChunkDistance = 3;
    public static int deltaChunkDistance = 1;
    // speed and multiplier
    public static float initialSpeed = 15;
    public static float deltaSpeed = 0.1f;
    public static float initialSpeedMultiplier = 1;
    public static float deltaSpeedMultiplier = 1;
    //score
    public static int initialPoints = 0;
    public static int pointsXWall = 1;
    public static int initialScoreMultiplier = 1;
    public static int deltaScoreMultiplier = 1;


    //
    public static int initialClusterDimension { private set; get; } = 20;

}