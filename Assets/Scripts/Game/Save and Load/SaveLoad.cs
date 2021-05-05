public static class SaveLoad
{
    public static int LoadCurrentScore() => PlayerPrefsSL.LoadCurrentScore();
    public static void SaveCurrentScore(int score) => PlayerPrefsSL.SaveCurrentScore(score);
    public static void ResetCurrentScore() => PlayerPrefsSL.ResetCurrentScore();

    public static int LoadHiScore() => PlayerPrefsSL.LoadBestScore();
    public static void SaveHiScore(int score) => PlayerPrefsSL.SaveBestScore(score);
    public static void ResetHiScore() => PlayerPrefsSL.ResetBestScore();


}
