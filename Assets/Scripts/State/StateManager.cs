using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateManager
{
    public static GameState GetGameState { private set; get; }
    public static bool isInitialized = false;

    public static Action OnMainMenu, OnPlay, OnPause, OnGameOver, OnReset;

    public static void UpdateState(GameState nextState)
    {
        GetGameState = nextState;
        switch (GetGameState)
        {
            case GameState.mainMenu:
                Time.timeScale = 0;
                isInitialized = false;
                OnMainMenu?.Invoke();
                break;

            case GameState.playing:
                Time.timeScale = 1;
                OnPlay?.Invoke();
                isInitialized = true;
                break;

            case GameState.paused:
                Time.timeScale = 0;
                OnPause?.Invoke();
                break;

            case GameState.gameOver:
                Time.timeScale = 1;
                OnGameOver?.Invoke();
                break;

            case GameState.reset:
                Time.timeScale = 1;
                isInitialized = false;
                SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
                // OnReset?.Invoke();
                break;

            default:
                break;
        }
    }

}
public enum GameState
{
    mainMenu, playing, paused, gameOver, reset
}
