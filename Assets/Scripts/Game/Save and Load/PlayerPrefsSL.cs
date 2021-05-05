using UnityEngine;

public static class PlayerPrefsSL
{
    public static int LoadCurrentScore()
    {
        return PlayerPrefs.HasKey(Utils.currentScoreKey) ? PlayerPrefs.GetInt(Utils.currentScoreKey) : 0;
    }

    public static int LoadBestScore()
    {
        return PlayerPrefs.HasKey(Utils.hiScoreKey) ? PlayerPrefs.GetInt(Utils.hiScoreKey) : 0;
    }

    public static void SaveCurrentScore(int score)
    {
        PlayerPrefs.SetInt(Utils.currentScoreKey, score);
    }

    public static void SaveBestScore(int score)
    {
        if (LoadBestScore() < score) PlayerPrefs.SetInt(Utils.hiScoreKey, score);
    }

    public static void ResetCurrentScore()
    {
        PlayerPrefs.SetInt(Utils.currentScoreKey, 0);
    }

    public static void ResetBestScore()
    {
        PlayerPrefs.SetInt(Utils.hiScoreKey, 0);
    }

}
