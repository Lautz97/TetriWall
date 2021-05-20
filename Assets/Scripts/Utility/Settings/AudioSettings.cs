public static class AudioSettings
{
    public const float DEFAULT_MasterVolume = 0.8f;
    public static float CurrentMasterVolume = DEFAULT_MasterVolume;
    public const float DEFAULT_MusicVolume = 0.8f;
    public static float CurrentMusicVolume = DEFAULT_MusicVolume;
    public const float DEFAULT_EffectsVolume = 0.8f;
    public static float CurrentEffectsVolume = DEFAULT_EffectsVolume;

    public const float DEFAULT_InitialPitch = 1.0f;
    public static float InitialPitch = DEFAULT_InitialPitch;
    public const float DEFAULT_InitialDeltaPitch = 0.00025f;
    public static float InitialDeltaPitch = DEFAULT_InitialDeltaPitch;

    public static float CurrentPitch;
    public static float CurrentDeltaPitch;
}
