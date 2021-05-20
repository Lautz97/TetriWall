public static class SaveLoadSettings
{
    public static string currentScoreKey { private set; get; } = "currentScore";
    public static string hiScoreKey { private set; get; } = "highestScore";

    public static string inputStyleBool { private set; get; } = "inputStyle";

    public static string masterVolumeFloat { private set; get; } = "masterVolume";
    public static string musicVolumeFloat { private set; get; } = "musicVolume";
    public static string effectsVolumeFloat { private set; get; } = "effectsVolume";
}