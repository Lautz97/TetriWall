using System;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    public static Action OnInputSettingsChangeRequest, OnInputSettingsChanged,
                        OnSettingsResetRequest, OnSettingsResetted,
                        OnSongChangeRequest, OnSongChanged,
                        OnVolumeChangeRequest, OnVolumeChanged,
                        OnTutorialChangeRequest, OnTutorialChanged,
                        OnVibrationChangeRequest, OnVibrationChanged,
                        OnVibrationMovementChangeRequest, OnVibrationMovementChanged,
                        OnVibrationButtonsChangeRequest, OnVibrationButtonsChanged;
    private void OnEnable()
    {
        RecallSaved();

        StateManager.OnLoading += RecallSaved;

        OnInputSettingsChangeRequest += ChangeInputSystem;
        OnTutorialChangeRequest += ChangeTutorial;

        OnSettingsResetRequest += ResetSettings;

        OnSongChangeRequest += SongChanged;
        OnVolumeChangeRequest += VolumeChanged;

        OnVibrationChangeRequest += ChangeVibration;
        OnVibrationMovementChangeRequest += ChangeVibrationMovement;
        OnVibrationButtonsChangeRequest += ChangeVibrationButtons;
    }

    private void OnDisable()
    {
        StateManager.OnLoading -= RecallSaved;

        OnInputSettingsChangeRequest -= ChangeInputSystem;
        OnTutorialChangeRequest -= ChangeTutorial;

        OnSettingsResetRequest -= ResetSettings;

        OnSongChangeRequest -= SongChanged;
        OnVolumeChangeRequest -= VolumeChanged;

        OnVibrationChangeRequest -= ChangeVibration;
        OnVibrationMovementChangeRequest -= ChangeVibrationMovement;
        OnVibrationButtonsChangeRequest -= ChangeVibrationButtons;
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

        // vibration
        RecallVibration();
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

        // vibration
        ResetVibration();
    }

    private void RecallVibration()
    {
        GamePlaySettings.vibration = SaveLoad.HasSetting(SaveLoadSettings.vibrationBool) ? SaveLoad.LoadBoolSettingsManually(SaveLoadSettings.vibrationBool) : GamePlaySettings.DEFAULT_vibration;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationBool, GamePlaySettings.vibration);
        OnVibrationChanged?.Invoke();

        GamePlaySettings.vibrationButtons = SaveLoad.HasSetting(SaveLoadSettings.vibrationButtonsBool) ? SaveLoad.LoadBoolSettingsManually(SaveLoadSettings.vibrationButtonsBool) : GamePlaySettings.DEFAULT_vibrationButtons;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationButtonsBool, GamePlaySettings.vibrationButtons);
        OnVibrationButtonsChanged?.Invoke();

        GamePlaySettings.vibrationMovement = SaveLoad.HasSetting(SaveLoadSettings.vibrationMovementBool) ? SaveLoad.LoadBoolSettingsManually(SaveLoadSettings.vibrationMovementBool) : GamePlaySettings.DEFAULT_vibrationMovement;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationMovementBool, GamePlaySettings.vibrationMovement);
        OnVibrationMovementChanged?.Invoke();
    }

    private void ResetVibration()
    {
        GamePlaySettings.vibration = GamePlaySettings.DEFAULT_vibration;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationBool, GamePlaySettings.vibration);
        OnVibrationChanged?.Invoke();

        GamePlaySettings.vibrationMovement = GamePlaySettings.DEFAULT_vibrationMovement;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationMovementBool, GamePlaySettings.vibrationMovement);
        OnVibrationMovementChanged?.Invoke();

        GamePlaySettings.vibrationButtons = GamePlaySettings.DEFAULT_vibrationButtons;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationButtonsBool, GamePlaySettings.vibrationButtons);
        OnVibrationButtonsChanged?.Invoke();
    }

    private void ChangeVibrationMovement()
    {
        if ((GamePlaySettings.vibration == false && GamePlaySettings.vibrationMovement == true) || GamePlaySettings.vibration == true)
        {
            GamePlaySettings.vibrationMovement = !GamePlaySettings.vibrationMovement;
            SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationMovementBool, GamePlaySettings.vibrationMovement);
            OnVibrationMovementChanged?.Invoke();
        }
    }
    private void ChangeVibrationButtons()
    {
        if ((GamePlaySettings.vibration == false && GamePlaySettings.vibrationButtons == true) || GamePlaySettings.vibration == true)
        {
            GamePlaySettings.vibrationButtons = !GamePlaySettings.vibrationButtons;
            SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationButtonsBool, GamePlaySettings.vibrationButtons);
            OnVibrationButtonsChanged?.Invoke();
        }
    }
    private void ChangeVibration()
    {
        GamePlaySettings.vibration = !GamePlaySettings.vibration;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.vibrationBool, GamePlaySettings.vibration);
        OnVibrationChanged?.Invoke();
        if (GamePlaySettings.vibration == false)
        {
            if (GamePlaySettings.vibrationMovement == true)
            {
                ChangeVibrationMovement();
            }
            if (GamePlaySettings.vibrationButtons == true)
            {
                ChangeVibrationButtons();
            }
        }
    }

    private void RecallTutorial()
    {
        GamePlaySettings.showTutorial = SaveLoad.HasSetting(SaveLoadSettings.showTutorial) ? SaveLoad.LoadBoolSettingsManually(SaveLoadSettings.showTutorial) : GamePlaySettings.DEFAULT_showTutorial;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.showTutorial, GamePlaySettings.showTutorial);
        OnTutorialChanged?.Invoke();
    }

    private void ResetTutorial()
    {
        GamePlaySettings.showTutorial = GamePlaySettings.DEFAULT_showTutorial;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.showTutorial, GamePlaySettings.showTutorial);
        OnTutorialChanged?.Invoke();
    }

    private void ChangeTutorial()
    {
        GamePlaySettings.showTutorial = !GamePlaySettings.showTutorial;
        SaveLoad.SaveBoolSettingsManually(SaveLoadSettings.showTutorial, GamePlaySettings.showTutorial);
        OnTutorialChanged?.Invoke();
    }

    private void RecallSong()
    {
        // Debug.Log("method not yet implemented");
        //OnSongChanged?.Invoke();
    }

    private void ResetSong()
    {
        // Debug.Log("method not yet implemented");
        //OnSongChanged?.Invoke();
    }

    private void SongChanged()
    {
        // Debug.Log("method not yet implemented");
        //OnSongChanged?.Invoke();
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
