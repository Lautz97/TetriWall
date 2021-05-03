using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoad
{
    public static int LoadCurrentScore()
    {
        return PlayerPrefsSL.LoadCurrentScore();
    }

    public static void SaveCurrentScore(int score)
    {
        PlayerPrefsSL.SaveCurrentScore(score);
    }
}
