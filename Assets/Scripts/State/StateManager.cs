using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateManager
{
    public static State GetGameState { private set; get; }

    public static Action OnMainMenu, OnInitialize, OnPause, OnResume, OnGameOver, OnReset;

    public static void MainMenu()
    {
        GetGameState = State.mainMenu;
        OnMainMenu?.Invoke();
    }
    public static void Initialize()
    {
        GetGameState = State.initializing;
        OnInitialize?.Invoke();
    }
    public static void Pause()
    {
        GetGameState = State.pausing;
        OnPause?.Invoke();
    }
    public static void Resume()
    {
        GetGameState = State.resuming;
        OnResume?.Invoke();
    }
    public static void GameOver()
    {
        GetGameState = State.gameover;
        OnGameOver?.Invoke();
    }
    public static void Reset()
    {
        GetGameState = State.resetting;
        OnReset?.Invoke();
        //PROBLEM
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }
    public static void Quit()
    {
        Application.Quit();
    }

}
public enum State
{
    mainMenu, initializing, pausing, resuming, gameover, resetting
}
