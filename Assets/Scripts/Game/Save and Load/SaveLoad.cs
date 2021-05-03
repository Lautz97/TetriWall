using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoad
{
    public static int LoadCurrentScore() => PlayerPrefsSL.LoadCurrentScore();

    public static void SaveCurrentScore(int score) => PlayerPrefsSL.SaveCurrentScore(score);



    public static int LoadHiScore() => PlayerPrefsSL.LoadBestScore();

    public static void SaveHiScore(int score) => PlayerPrefsSL.SaveBestScore(score);
    public static void ResetHiScore(int score) => PlayerPrefsSL.ResetBestScore();

}
