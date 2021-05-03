using System;
using UnityEngine;

public static class StateManager
{
    public static GameState GetGameState { private set; get; }

    public static Action OnMainMenu, OnPlay, OnPause, OnGameOver;

    public static void UpdateState(GameState nextState)
    {
        GetGameState = nextState;
        switch (GetGameState)
        {
            case GameState.mainMenu:
                Time.timeScale = 0;
                OnMainMenu?.Invoke();
                break;

            case GameState.playing:
                Time.timeScale = 1;
                OnPlay?.Invoke();
                break;

            case GameState.paused:
                Time.timeScale = 0;
                OnPause?.Invoke();
                break;

            case GameState.gameOver:
                Time.timeScale = 1;
                OnGameOver?.Invoke();
                break;

            default:
                break;
        }
    }

}
public enum GameState
{
    mainMenu, playing, paused, gameOver
}
