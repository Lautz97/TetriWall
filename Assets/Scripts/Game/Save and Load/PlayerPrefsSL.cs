using System;
using UnityEngine;

public static class PlayerPrefsSL
{
    internal static int LoadCurrentScore => PlayerPrefs.HasKey(SaveLoadSettings.currentScoreKey) ? PlayerPrefs.GetInt(SaveLoadSettings.currentScoreKey) : 0;

    internal static int LoadBestScore => PlayerPrefs.HasKey(SaveLoadSettings.hiScoreKey) ? PlayerPrefs.GetInt(SaveLoadSettings.hiScoreKey) : 0;

    internal static void SaveCurrentScore(int score) => PlayerPrefs.SetInt(SaveLoadSettings.currentScoreKey, score);

    internal static void SaveBestScore(int score)
    {
        if (LoadBestScore < score) PlayerPrefs.SetInt(SaveLoadSettings.hiScoreKey, score);
    }

    internal static void ResetCurrentScore() => PlayerPrefs.SetInt(SaveLoadSettings.currentScoreKey, 0);

    internal static void ResetBestScore() => PlayerPrefs.SetInt(SaveLoadSettings.hiScoreKey, 0);


    // int
    internal static void SaveIntSettingsManually(string setting, int item) => PlayerPrefs.SetInt(setting, item);
    internal static int LoadIntSettingsManually(string setting) => PlayerPrefs.GetInt(setting);

    // float
    internal static void SaveFloatSettingsManually(string setting, float item) => PlayerPrefs.SetFloat(setting, item);
    internal static float LoadFloatSettingsManually(string setting) => PlayerPrefs.GetFloat(setting);

    // string
    internal static void SaveStringSettingsManually(string setting, string item) => PlayerPrefs.SetString(setting, item);
    internal static string LoadStringSettingsManually(string setting) => PlayerPrefs.GetString(setting);

    // boolean 
    internal static void SaveBoolSettingsManually(string setting, bool item)
    {
        if (item == true) PlayerPrefs.SetInt(setting, 1); else PlayerPrefs.SetInt(setting, 0);
    }

    internal static bool LoadBoolSettingsManually(string setting)
    {
        if (PlayerPrefs.GetInt(setting) == 1) return true;
        if (PlayerPrefs.GetInt(setting) == 0) return false;
        return false;
    }

    // has setting
    internal static bool HasSetting(string setting) => PlayerPrefs.HasKey(setting);

}
