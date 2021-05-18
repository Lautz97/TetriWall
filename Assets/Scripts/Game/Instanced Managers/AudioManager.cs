using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    string _musicVolume = "MusicVolume", _effectsVolume = "EffectsVolume", _masterVolume = "MasterVolume", _musicPitch = "MusicPitch";
    [SerializeField] AudioSource MusicSource, EffectsSource;
    [SerializeField] AudioMixer MusicMixer, EffectsMixer, MasterMixer;
    private float _multiplier = 30f;

    private void OnEnable()
    {
        StateManager.OnMainMenu += UpdateVolume;

        SettingsManager.OnVolumeChanged += UpdateVolume;
        // SettingsManager.OnSongChanged += ButtonsCheck;
    }

    private void OnDisable()
    {
        StateManager.OnMainMenu -= UpdateVolume;

        SettingsManager.OnVolumeChanged -= UpdateVolume;
        // SettingsManager.OnSongChanged -= ButtonsCheck;
    }
    private void UpdateVolume()
    {
        MasterMixer.SetFloat(_masterVolume, Mathf.Log10(AudioSettings.CurrentMasterVolume + float.Epsilon) * _multiplier);
        MusicMixer.SetFloat(_musicVolume, Mathf.Log10(AudioSettings.CurrentMusicVolume + float.Epsilon) * _multiplier);
        EffectsMixer.SetFloat(_effectsVolume, Mathf.Log10(AudioSettings.CurrentEffectsVolume + float.Epsilon) * _multiplier);
    }
}
