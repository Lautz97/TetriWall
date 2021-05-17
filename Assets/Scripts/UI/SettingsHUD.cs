using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsHUD : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] Button ResetScoreBtn;
    [SerializeField] Button ContinuousInputBtn, DiscreteInputBtn;
    [SerializeField] Slider MasterVolumeSlider, MusicVolumeSlider, EffectsVolumeSlider;
    [SerializeField] Button ShowTutorialBtn, HideTutorialBtn;
    [SerializeField] GameObject GameplayTab, AudioTab;
    [SerializeField] GameObject OpenGameplayTabBtn, OpenAudioTabBtn;
    private void Awake()
    {
        ResetScoreBtn.interactable = (SaveLoad.LoadHiScore() > 0);
        ButtonsCheck();
    }

    public void MainMenu()
    {
        MenuPanel.SetActive(true);
        gameObject.SetActive(false);

        ButtonsCheck();
    }

    private void OnEnable()
    {
        AudioTab.SetActive(false);
        OpenAudioTabBtn.SetActive(true);

        GameplayTab.SetActive(false);
        OpenGameplayTabBtn.SetActive(true);

        SettingsManager.OnInputSettingsChanged += ButtonsCheck;
        SettingsManager.OnSettingsResetted += ButtonsCheck;
        SettingsManager.OnVolumeChanged += ButtonsCheck;
        SettingsManager.OnTutorialChanged += ButtonsCheck;
        SettingsManager.OnSongChanged += ButtonsCheck;
    }

    private void OnDisable()
    {
        SettingsManager.OnInputSettingsChanged -= ButtonsCheck;
        SettingsManager.OnSettingsResetted -= ButtonsCheck;
        SettingsManager.OnVolumeChanged -= ButtonsCheck;
        SettingsManager.OnTutorialChanged -= ButtonsCheck;
        SettingsManager.OnSongChanged -= ButtonsCheck;
    }

    public void ToggleAudioSettingsTab()
    {
        if (OpenAudioTabBtn.activeInHierarchy)
        {
            OpenAudioTabBtn.SetActive(false);
            AudioTab.SetActive(true);
        }
        else
        {
            AudioTab.SetActive(false);
            OpenAudioTabBtn.SetActive(true);
        }
    }
    public void ToggleGameSettingsTab()
    {
        if (OpenGameplayTabBtn.activeInHierarchy)
        {
            OpenGameplayTabBtn.SetActive(false);
            GameplayTab.SetActive(true);
        }
        else
        {
            GameplayTab.SetActive(false);
            OpenGameplayTabBtn.SetActive(true);
        }
    }

    public void QuitGame()
    {
        StateManager.Quit();
    }

    public void ResetHiScore()
    {
        SaveLoad.ResetHiScore();
        ButtonsCheck();
    }

    public void ResetSettings()
    {
        SettingsManager.OnSettingsResetRequest?.Invoke();
        ButtonsCheck();
    }

    public void ChangeInputSystem()
    {
        SettingsManager.OnInputSettingsChangeRequest?.Invoke();
        ButtonsCheck();
    }

    public void ChangeVolume()
    {
        VolumeSlidersCheck();
        Debug.Log("method not yet implemented");
    }

    public void ChangeTutorial()
    {
        TutorialButtonsCheck();
        Debug.Log("method not yet implemented");
    }

    public void ChangeSong()
    {
        SongButtonsCheck();
        Debug.Log("method not yet implemented");
    }


    private void ButtonsCheck()
    {
        InputButtonsCheck();
        HiScoreButtonCheck();
        VolumeSlidersCheck();
        SongButtonsCheck();
        TutorialButtonsCheck();
    }

    private void InputButtonsCheck()
    {
        if (InputSettings.discreteInputCheck)
        {
            DiscreteInputBtn.interactable = true;
            ContinuousInputBtn.interactable = false;
        }
        else
        {
            ContinuousInputBtn.interactable = true;
            DiscreteInputBtn.interactable = false;
        }
    }

    private void HiScoreButtonCheck()
    {
        ResetScoreBtn.interactable = (SaveLoad.LoadHiScore() > 0);
    }

    private void VolumeSlidersCheck()
    {
        Debug.Log("method not yet implemented");
    }

    private void SongButtonsCheck()
    {
        Debug.Log("method not yet implemented");
    }

    private void TutorialButtonsCheck()
    {
        Debug.Log("method not yet implemented");
    }
}
