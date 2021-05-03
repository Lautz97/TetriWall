using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static GameState gameState { private set; get; }
    public static Action OnMainMenu, OnGameLoopStart, OnPaused, OnGameOver, OnLoading;

    public void MainMenu()
    {
        gameState = GameState.mainMenu;
        OnMainMenu?.Invoke();
    }

    public void GameLoop()
    {
        gameState = GameState.gameLoop;
        OnGameLoopStart?.Invoke();
    }

    public void Pause()
    {
        gameState = GameState.pause;
        OnPaused?.Invoke();
    }

    public void GameOver()
    {
        gameState = GameState.gameOver;
        OnGameOver?.Invoke();
    }

    public void Loading()
    {
        gameState = GameState.loading;
        OnLoading?.Invoke();
    }
}

public enum GameState
{
    mainMenu, gameLoop, pause, gameOver, loading
}
