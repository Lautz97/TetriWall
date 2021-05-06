using UnityEngine;

public static class PlayerPrefsSL
{
    public static int LoadCurrentScore()
    {
        return PlayerPrefs.HasKey(SaveLoadSettings.currentScoreKey) ? PlayerPrefs.GetInt(SaveLoadSettings.currentScoreKey) : 0;
    }

    public static int LoadBestScore()
    {
        return PlayerPrefs.HasKey(SaveLoadSettings.hiScoreKey) ? PlayerPrefs.GetInt(SaveLoadSettings.hiScoreKey) : 0;
    }

    public static void SaveCurrentScore(int score)
    {
        PlayerPrefs.SetInt(SaveLoadSettings.currentScoreKey, score);
    }

    public static void SaveBestScore(int score)
    {
        if (LoadBestScore() < score) PlayerPrefs.SetInt(SaveLoadSettings.hiScoreKey, score);
    }

    public static void ResetCurrentScore()
    {
        PlayerPrefs.SetInt(SaveLoadSettings.currentScoreKey, 0);
    }

    public static void ResetBestScore()
    {
        PlayerPrefs.SetInt(SaveLoadSettings.hiScoreKey, 0);
    }

}
