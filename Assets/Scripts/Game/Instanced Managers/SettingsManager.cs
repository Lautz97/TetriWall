using System;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    public static Action OnInputSettingsChangeRequest, OnInputSettingsChanged,
                        OnSettingsResetRequest, OnSettingsResetted,
                        OnSongChangeRequest, OnSongChanged,
                        OnVolumeChangeRequest, OnVolumeChanged,
                        OnTutorialChangeRequest, OnTutorialChanged;
    private void OnEnable()
    {
        RecallSaved();

        StateManager.OnMainMenu += RecallSaved;
        StateManager.OnReset += RecallSaved;

        OnInputSettingsChangeRequest += ChangeInputSystem;
        OnTutorialChangeRequest += ChangeTutorial;

        OnSettingsResetRequest += ResetSettings;

        OnSongChangeRequest += SongChanged;
        OnVolumeChangeRequest += VolumeChanged;
    }

    private void OnDisable()
    {
        StateManager.OnMainMenu -= RecallSaved;
        StateManager.OnReset -= RecallSaved;

        OnInputSettingsChangeRequest -= ChangeInputSystem;
        OnTutorialChangeRequest -= ChangeTutorial;

        OnSettingsResetRequest -= ResetSettings;

        OnSongChangeRequest -= SongChanged;
        OnVolumeChangeRequest -= VolumeChanged;
    }

    private void RecallSaved()
    {
        // input
        RecallInput();

        // gameplay
        ResetGamePlay();

        // volume 
        RecallVolume();

        // song
        RecallSong();

        // tutorial
        RecallTutorial();
    }

    private void ResetSettings()
    {
        // input
        ResetInput();

        // gameplay
        ResetGamePlay();

        // volume
        ResetVolume();

        // song
        ResetSong();

        // tutorial
        ResetTutorial();
    }

    private void RecallTutorial()
    {
        Debug.Log("method not yet implemented");
        OnTutorialChanged?.Invoke();
    }

    private void ResetTutorial()
    {
        Debug.Log("method not yet implemented");
        OnTutorialChanged?.Invoke();
    }

    private void ChangeTutorial()
    {
        Debug.Log("method not yet implemented");
        OnTutorialChanged?.Invoke();
    }

    private void RecallSong()
    {
        Debug.Log("method not yet implemented");
        OnSongChanged?.Invoke();
    }

    private void ResetSong()
    {
        Debug.Log("method not yet implemented");
        OnSongChanged?.Invoke();
    }

    private void SongChanged()
    {
        Debug.Log("method not yet implemented");
        OnSongChanged?.Invoke();
    }

    private void RecallVolume()
    {
        if (SaveLoad.HasSetting(SaveLoadSettings.masterVolumeFloat))
            AudioSettings.CurrentMasterVolume = SaveLoad.LoadFloatSettingsManually(SaveLoadSettings.masterVolumeFloat);
        else
            AudioSettings.CurrentMasterVolume = AudioSettings.DEFAULT_MasterVolume;

        if (SaveLoad.HasSetting(SaveLoadSettings.musicVolumeFloat))
            AudioSettings.CurrentMusicVolume = SaveLoad.LoadFloatSettingsManually(SaveLoadSettings.musicVolumeFloat);
        else
            AudioSettings.CurrentMusicVolume = AudioSettings.DEFAULT_MusicVolume;

        if (SaveLoad.HasSetting(SaveLoadSettings.effectsVolumeFloat))
            AudioSettings.CurrentEffectsVolume = SaveLoad.LoadFloatSettingsManually(SaveLoadSettings.effectsVolumeFloat);
        else
            AudioSettings.CurrentEffectsVolume = AudioSettings.DEFAULT_EffectsVolume;

        VolumeChanged();
    }

    private void ResetVolume()
    {
        AudioSettings.CurrentMasterVolume = AudioSettings.DEFAULT_MasterVolume;
        AudioSettings.CurrentMusicVolume = AudioSettings.DEFAULT_MusicVolume;
        AudioSettings.CurrentEffectsVolume = AudioSettings.DEFAULT_EffectsVolume;

        AudioSettings.InitialPitch = AudioSettings.DEFAULT_InitialPitch;
        AudioSettings.InitialDeltaPitch = AudioSettings.DEFAULT_InitialDeltaPitch;
        VolumeChanged();
    }


    private void VolumeChanged()
    {
        SaveLoad.SaveFloatSettingsManually(SaveLoadSettings.masterVolumeFloat, AudioSettings.CurrentMasterVolume);

        SaveLoad.SaveFloatSettingsManually(SaveLoadSettings.musicVolumeFloat, AudioSettings.CurrentMusicVolume);

        SaveLoad.SaveFloatSettingsManually(SaveLoadSettings.effectsVolumeFloat, AudioSettings.CurrentEffectsVolume);

        OnVolumeChanged?.Invoke();
    }

    private void ResetGamePlay()
    {
        // / chunks
        GamePlaySettings.initialChunkDistance = GamePlaySettings.DEFAULT_initialChunkDistance;
        GamePlaySettings.deltaChunkDistance = GamePlaySettings.DEFAULT_deltaChunkDistance;
        // / speed
        GamePlaySettings.initialSpeed = GamePlaySettings.DEFAULT_initialSpeed;
        GamePlaySettings.initialSpeedMultiplier = GamePlaySettings.DEFAULT_initialSpeedMultiplier;
        GamePlaySettings.initialdeltaSpeed = GamePlaySettings.DEFAULT_initialdeltaSpeed;
        GamePlaySettings.deltaSpeedMultiplier = GamePlaySettings.DEFAULT_deltaSpeedMultiplier;
        // / score
        GamePlaySettings.initialPoints = GamePlaySettings.DEFAULT_initialPoints;
        GamePlaySettings.pointsXWall = GamePlaySettings.DEFAULT_pointsXWall;
        GamePlaySettings.initialScoreMultiplier = GamePlaySettings.DEFAULT_initialScoreMultiplier;
        GamePlaySettings.deltaScoreMultiplier = GamePlaySettings.DEFAULT_deltaScoreMultiplier;

        OnSettingsResetted?.Invoke();
    }

    private void RecallInput()
    {
        if (SaveLoad.HasSetting(SaveLoadSettings.inputStyleBool))
            InputSettings.discreteInputCheck = !SaveLoad.LoadBoolSettingsManually(SaveLoadSettings.inputStyleBool);
        else
            InputSettings.discreteInputCheck = !InputSettings.DEFAULT_detectOnlyAfterRelease;
        ChangeInputSystem();
    }

    private void ResetInput()
    {
        InputSettings.discreteInputCheck = !InputSettings.DEFAULT_detectOnlyAfterRelease;
        ChangeInputSystem();
    }

    private void ChangeInputSystem()
    {
        InputSettings.discreteInputCheck = !InputSettings.discreteInputCheck;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.inputStyleBool, InputSettings.discreteInputCheck);
        InputSystemValueCheck();
    }

    private void InputSystemValueCheck()
    {
        if (!InputSettings.discreteInputCheck)
        {
            InputSettings.maxSwipeTime = InputSettings.DEFAULT_maxSwipeTime_continuous;
            InputSettings.maxTapDistance = InputSettings.DEFAULT_maxTapDistance_continuous;
            InputSettings.maxTapTime = InputSettings.DEFAULT_maxTapTime_continuous;
            InputSettings.minSwipeDistance = InputSettings.DEFAULT_minSwipeDistance_continuous;
        }
        if (InputSettings.discreteInputCheck)
        {
            InputSettings.maxSwipeTime = InputSettings.DEFAULT_maxSwipeTime_discrete;
            InputSettings.maxTapDistance = InputSettings.DEFAULT_maxTapDistance_discrete;
            InputSettings.maxTapTime = InputSettings.DEFAULT_maxTapTime_discrete;
            InputSettings.minSwipeDistance = InputSettings.DEFAULT_minSwipeDistance_discrete;
        }

        OnInputSettingsChanged?.Invoke();
    }
}
