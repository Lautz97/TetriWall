using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    string _musicVolume = "MusicVolume", _effectsVolume = "EffectsVolume", _masterVolume = "MasterVolume", _musicPitch = "MusicPitch";
    [SerializeField]
    AudioSource musicSource, menuSource, pauseSource, gameOverSource,
                                btnSource, inputSource;
    [SerializeField] AudioMixer masterMixer;/*MusicMixer, EffectsMixer, */
    private float _multiplier = 30f;

    [SerializeField] AudioClip buttonClip = null, swipeClip = null, tapClip = null;
    [SerializeField] AudioClip bgmClip = null, menuClip = null, gameOverClip = null, pauseClip = null;



    private void OnEnable()
    {
        StateManager.OnMainMenu += UpdateVolume;

        SettingsManager.OnVolumeChanged += UpdateVolume;
        // SettingsManager.OnSongChanged += ButtonsCheck;

        SwipeDetector.OnSwipe += InputPressed;

        StateManager.OnMainMenu += PlayMenuMusic;
        StateManager.OnInitialize += PlayGameMusic;
        StateManager.OnGameOver += PlayGameOverMusic;
        StateManager.OnPause += PlayPauseMusic;
        StateManager.OnResume += PlayGameMusic;

        PlayMenuMusic();
    }

    private void OnDisable()
    {
        StateManager.OnMainMenu -= UpdateVolume;

        SettingsManager.OnVolumeChanged -= UpdateVolume;
        // SettingsManager.OnSongChanged -= ButtonsCheck;

        SwipeDetector.OnSwipe -= InputPressed;

        StateManager.OnMainMenu -= PlayMenuMusic;
        StateManager.OnInitialize -= PlayGameMusic;
        StateManager.OnGameOver -= PlayGameOverMusic;
        StateManager.OnPause -= PlayPauseMusic;
        StateManager.OnResume -= PlayGameMusic;
    }
    private void UpdateVolume()
    {
        masterMixer.SetFloat(_masterVolume, Mathf.Log10(AudioSettings.CurrentMasterVolume + float.Epsilon) * _multiplier);
        masterMixer.SetFloat(_musicVolume, Mathf.Log10(AudioSettings.CurrentMusicVolume + float.Epsilon) * _multiplier);
        masterMixer.SetFloat(_effectsVolume, Mathf.Log10(AudioSettings.CurrentEffectsVolume + float.Epsilon) * _multiplier);
    }

    private void PauseAll()
    {
        if (musicSource.isPlaying) musicSource.Pause();
        if (menuSource.isPlaying) menuSource.Pause();
        if (pauseSource.isPlaying) pauseSource.Pause();
        if (gameOverSource.isPlaying) gameOverSource.Pause();
    }

    private void PlayGameMusic()
    {
        PauseAll();
        if (bgmClip != null && musicSource.clip != bgmClip)
        {
            musicSource.loop = true;
            musicSource.clip = bgmClip;
            musicSource.Play();
        }
        else
        {
            musicSource.UnPause();
        }
    }

    private void PlayMenuMusic()
    {
        if (StateManager.GetGameState == State.mainMenu)
        {
            PauseAll();
            if (menuClip != null && menuSource.clip != menuClip)
            {
                menuSource.loop = true;
                menuSource.clip = menuClip;
                menuSource.Play();
            }
            else
            {
                menuSource.UnPause();
            }
        }
    }

    private void PlayPauseMusic()
    {
        PauseAll();
        if (pauseClip != null && pauseSource.clip != pauseClip)
        {
            pauseSource.loop = true;
            pauseSource.clip = pauseClip;
            pauseSource.Play();
        }
        else
        {
            pauseSource.UnPause();
        }
    }

    private void PlayGameOverMusic()
    {
        PauseAll();
        if (gameOverClip != null && gameOverSource.clip != gameOverClip)
        {
            gameOverSource.loop = true;
            gameOverSource.clip = gameOverClip;
            gameOverSource.PlayOneShot(gameOverClip);
        }
        else
        {
            gameOverSource.PlayOneShot(gameOverClip);
        }
    }

    public void ButtonPressed()
    {
        AudioClip fx = buttonClip;
        if (fx != null)
        {
            btnSource.PlayOneShot(fx);
        }
    }

    private void InputPressed(SwipeData v)
    {
        Vector2 v1 = v.Direction;
        if (v1 == Vector2.zero)
        {
            inputSource.PlayOneShot(tapClip);
        }
        else
        {
            inputSource.PlayOneShot(swipeClip);
        }
    }

}
