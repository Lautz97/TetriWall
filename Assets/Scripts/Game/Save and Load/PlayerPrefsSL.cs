using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsSL
{
    public static int LoadCurrentScore()
    {
        return PlayerPrefs.HasKey(Utils.currentScoreKey) ? PlayerPrefs.GetInt(Utils.currentScoreKey) : 0;
    }

    public static void SaveCurrentScore(int score)
    {
        PlayerPrefs.SetInt(Utils.currentScoreKey, score);
    }
}
