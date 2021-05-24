using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsHUD : MonoBehaviour
{
    private bool protectedChange = false;


    [SerializeField] GameObject MenuPanel;
    [SerializeField] Button ResetScoreBtn;
    [SerializeField] Button ContinuousInputBtn, DiscreteInputBtn;
    [SerializeField] TMP_Text MasterVolumeText, MusicVolumeText, EffectsVolumeText;
    [SerializeField] Slider MasterVolumeSlider, MusicVolumeSlider, EffectsVolumeSlider;
    [SerializeField] Button ShowTutorialBtn, HideTutorialBtn;
    [SerializeField] GameObject GameplayTab, AudioTab;
    [SerializeField] GameObject OpenGameplayTabBtn, OpenAudioTabBtn;

    private void Start()
    {
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
        CloseTabs();

        SettingsManager.OnSettingsResetted += ButtonsCheck;
        SettingsManager.OnInputSettingsChanged += InputButtonsCheck;
        SettingsManager.OnVolumeChanged += VolumeSlidersCheck;
        SettingsManager.OnTutorialChanged += TutorialButtonsCheck;
        SettingsManager.OnSongChanged += SongButtonsCheck;
    }

    private void OnDisable()
    {
        SettingsManager.OnInputSettingsChanged -= InputButtonsCheck;
        SettingsManager.OnSettingsResetted -= ButtonsCheck;
        SettingsManager.OnVolumeChanged -= VolumeSlidersCheck;
        SettingsManager.OnTutorialChanged -= TutorialButtonsCheck;
        SettingsManager.OnSongChanged -= SongButtonsCheck;
    }

    private void CloseTabs()
    {
        AudioTab.SetActive(false);
        OpenAudioTabBtn.SetActive(true);

        GameplayTab.SetActive(false);
        OpenGameplayTabBtn.SetActive(true);
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
        HiScoreButtonCheck();
    }

    public void ResetSettings()
    {
        SettingsManager.OnSettingsResetRequest?.Invoke();
    }

    public void ChangeInputSystem()
    {
        SettingsManager.OnInputSettingsChangeRequest?.Invoke();
    }

    public void ChangeVolume()
    {
        if (!protectedChange)
        {
            AudioSettings.CurrentMasterVolume = MasterVolumeSlider.value;
            AudioSettings.CurrentMusicVolume = MusicVolumeSlider.value;
            AudioSettings.CurrentEffectsVolume = EffectsVolumeSlider.value;
            SettingsManager.OnVolumeChangeRequest?.Invoke();
        }
    }

    public void ChangeTutorial()
    {
        SettingsManager.OnTutorialChangeRequest?.Invoke();
    }

    public void ChangeSong()
    {
        SongButtonsCheck();
        // Debug.Log("method not yet implemented");
    }


    private void ButtonsCheck()
    {
        InputButtonsCheck();
        HiScoreButtonCheck();

        VolumeSlidersCheck();
        // SettingsManager.OnVolumeChanged?.Invoke();

        SongButtonsCheck();
        TutorialButtonsCheck();
    }

    private void InputButtonsCheck()
    {
        if (!InputSettings.discreteInputCheck)
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
        protectedChange = true;

        MasterVolumeSlider.value = AudioSettings.CurrentMasterVolume;
        MasterVolumeText.text = "Master Volume: " + Mathf.RoundToInt(AudioSettings.CurrentMasterVolume * 100);

        MusicVolumeSlider.value = AudioSettings.CurrentMusicVolume;
        MusicVolumeText.text = "Music Volume: " + Mathf.RoundToInt(AudioSettings.CurrentMusicVolume * 100);

        EffectsVolumeSlider.value = AudioSettings.CurrentEffectsVolume;
        EffectsVolumeText.text = "Effects Volume: " + Mathf.RoundToInt(AudioSettings.CurrentEffectsVolume * 100);

        protectedChange = false;
    }

    private void SongButtonsCheck()
    {
        // Debug.Log("method not yet implemented");
    }

    private void TutorialButtonsCheck()
    {
        if (GamePlaySettings.showTutorial)
        {
            ShowTutorialBtn.interactable = false;
            HideTutorialBtn.interactable = true;
        }
        if (!GamePlaySettings.showTutorial)
        {
            HideTutorialBtn.interactable = false;
            ShowTutorialBtn.interactable = true;
        }

    }
}
