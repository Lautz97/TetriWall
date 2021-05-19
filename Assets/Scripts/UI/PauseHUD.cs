using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseHUD : MonoBehaviour
{
    [SerializeField] private GameObject InputMan;

    [SerializeField] GameObject GameplayTab, AudioTab;
    [SerializeField] GameObject OpenGameplayTabBtn, OpenAudioTabBtn;

    [SerializeField] Button ContinuousInputBtn, DiscreteInputBtn;
    [SerializeField] TMP_Text MasterVolumeText, MusicVolumeText, EffectsVolumeText;
    [SerializeField] Slider MasterVolumeSlider, MusicVolumeSlider, EffectsVolumeSlider;

    private void OnEnable()
    {
        InputMan.SetActive(false);
        CloseTabs();
        InputButtonsCheck();
        VolumeSlidersCheck();

        SettingsManager.OnInputSettingsChanged += InputButtonsCheck;
        SettingsManager.OnVolumeChanged += VolumeSlidersCheck;

        SettingsManager.OnSettingsResetted += InputButtonsCheck;
        SettingsManager.OnSettingsResetted += VolumeSlidersCheck;
    }
    private void OnDisable()
    {
        InputMan.SetActive(true);

        SettingsManager.OnInputSettingsChanged -= InputButtonsCheck;
        SettingsManager.OnVolumeChanged -= VolumeSlidersCheck;

        SettingsManager.OnSettingsResetted -= InputButtonsCheck;
        SettingsManager.OnSettingsResetted -= VolumeSlidersCheck;
    }


    public void ResumeGame()
    {
        StateManager.Resume();
    }

    public void QuitToMenu()
    {
        //TODO FIX THIS
        StateManager.Reset();
    }

    public void QuitGame()
    {
        // DONE for now
        // se il gioco viene chiuso dal menu di pausa
        // non far perdere i progressi al giocatore
        // salvare punteggi etc
        StateManager.Quit();
    }

    // public void TestMenu()
    // {
    //     gameObject.GetComponent<TestingHUD>().enabled = !gameObject.GetComponent<TestingHUD>().enabled;
    // }

    private bool protectedChange = false;

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

    public void ResetSettings()
    {
        SettingsManager.OnSettingsResetRequest?.Invoke();
    }

}
