public static class SaveLoad
{
    public static int LoadCurrentScore() => PlayerPrefsSL.LoadCurrentScore;
    public static void SaveCurrentScore(int score) => PlayerPrefsSL.SaveCurrentScore(score);
    public static void ResetCurrentScore() => PlayerPrefsSL.ResetCurrentScore();

    public static int LoadHiScore() => PlayerPrefsSL.LoadBestScore;
    public static void SaveHiScore(int score) => PlayerPrefsSL.SaveBestScore(score);
    public static void ResetHiScore() => PlayerPrefsSL.ResetBestScore();

    //save
    public static void SaveIntSettingsManually(string setting, int item) => PlayerPrefsSL.SaveIntSettingsManually(setting, item);
    public static void SaveFloatSettingsManually(string setting, float item) => PlayerPrefsSL.SaveFloatSettingsManually(setting, item);
    public static void SaveStringSettingsManually(string setting, string item) => PlayerPrefsSL.SaveStringSettingsManually(setting, item);
    public static void SaveBoolSettingsManually(string setting, bool item) => PlayerPrefsSL.SaveBoolSettingsManually(setting, item);

    //load
    public static int LoadIntSettingsManually(string setting) => PlayerPrefsSL.LoadIntSettingsManually(setting);
    public static float LoadFloatSettingsManually(string setting) => PlayerPrefsSL.LoadFloatSettingsManually(setting);
    public static string LoadStringSettingsManually(string setting) => PlayerPrefsSL.LoadStringSettingsManually(setting);
    public static bool LoadBoolSettingsManually(string setting) => PlayerPrefsSL.LoadBoolSettingsManually(setting);

    // settings present

    public static bool HasSetting(string setting) => PlayerPrefsSL.HasSetting(setting);

}
