public static class SaveLoadSettings
{
    public static string currentScoreKey { private set; get; } = "currentScore";
    public static string hiScoreKey { private set; get; } = "highestScore";

    public static string inputStyleBool { private set; get; } = "inputStyle";
    public static string showTutorial { private set; get; } = "showTutorial";

    public static string masterVolumeFloat { private set; get; } = "masterVolume";
    public static string musicVolumeFloat { private set; get; } = "musicVolume";
    public static string effectsVolumeFloat { private set; get; } = "effectsVolume";
    public static string vibrationBool { private set; get; } = "vibration";
    public static string vibrationMovementBool { private set; get; } = "vibrationMovement";
    public static string vibrationButtonsBool { private set; get; } = "vibrationButtons";
}