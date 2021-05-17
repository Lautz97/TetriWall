using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource MusicSource, EffectsSource;
    [SerializeField] AudioMixer MusicMixer, EffectsMixer, MasterMixer;

    private void OnEnable()
    {
        SettingsManager.OnVolumeChanged += UpdateVolume;
        // SettingsManager.OnSongChanged += ButtonsCheck;
    }

    private void OnDisable()
    {
        SettingsManager.OnVolumeChanged -= UpdateVolume;
        // SettingsManager.OnSongChanged -= ButtonsCheck;
    }
    private void UpdateVolume()
    {

    }

}
