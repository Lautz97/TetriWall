public static class ScoreManager
{

    public static void Initialize()
    {
        ResetCurrentScore();
        ResetScoreMultiplier();
    }

    // Add to current Points the just earned point quantity, counting also the multiplier
    public static void AddPoints()
    {
        GamePlayCounters.actualScore += GamePlaySettings.pointsXWall * GamePlayCounters.actualScoreMultiplier;
        SaveScoring();
    }




    // Saves both current and highest score, and possibly also the other variables.
    // player may continue even if closed the game by error.
    public static void SaveScoring()
    {
        SaveLoad.SaveCurrentScore(GamePlayCounters.actualScore);
        SaveLoad.SaveHiScore(GamePlayCounters.actualScore);
    }


    // this will increase the multiplier
    public static void IncreaseScoreMultiplier()
    {
        GamePlayCounters.actualScoreMultiplier += GamePlaySettings.deltaScoreMultiplier;
    }

    // this will decrease the multiplier
    public static void DecreaseScoreMultiplier()
    {
        GamePlayCounters.actualScoreMultiplier -= GamePlaySettings.deltaScoreMultiplier;
    }




    // method for resetting current score
    public static void ResetCurrentScore()
    {
        SaveLoad.ResetCurrentScore();
        GamePlayCounters.actualScore = SaveLoad.LoadCurrentScore();
    }

    // method for resetting best score
    public static void ResetBestScore()
    {
        SaveLoad.ResetHiScore();
    }

    // this will reset the multiplier
    public static void ResetScoreMultiplier()
    {
        GamePlayCounters.actualScoreMultiplier = GamePlaySettings.initialScoreMultiplier;
    }
}
