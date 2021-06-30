using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel, pausePanel, loadingPanel, gameloopPanel, gameoverPanel;
    [SerializeField] private Transform[] ignorable;
    private void OnEnable()
    {
        StateManager.OnLoading += ActivateLoading;
        StateManager.OnGameOver += ActivateGameOver;
        StateManager.OnMainMenu += ActivateMainMenu;
        StateManager.OnPause += AcivatePause;
        StateManager.OnResume += ActivateGameLoop;
        StateManager.OnInitialize += ActivateGameLoop;

        StateManager.OnPlayAgain += AutoStartGame;

        StateManager.MainMenu();
    }
    private void OnDisable()
    {
        StateManager.OnLoading -= ActivateLoading;
        StateManager.OnGameOver -= ActivateGameOver;
        StateManager.OnMainMenu -= ActivateMainMenu;
        StateManager.OnPause -= AcivatePause;
        StateManager.OnResume -= ActivateGameLoop;
        StateManager.OnInitialize -= ActivateGameLoop;

        StateManager.OnPlayAgain -= AutoStartGame;
    }

    private void DisableAllPanels()
    {
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
        }
        foreach (Transform a in ignorable)
        {
            a.gameObject.SetActive(true);
        }
    }
    private void ActivateMainMenu()
    {
        DisableAllPanels();
        menuPanel.SetActive(true);
        InputConstraintOverHUD.OnFilterNeeded?.Invoke();
    }
    private void AcivatePause()
    {
        DisableAllPanels();
        pausePanel.SetActive(true);
        InputConstraintOverHUD.OnFilterNeeded?.Invoke();
    }
    private void ActivateGameLoop()
    {
        DisableAllPanels();
        gameloopPanel.SetActive(true);
        InputConstraintOverHUD.OnFilterRemoved?.Invoke();
    }
    private void ActivateGameOver()
    {
        DisableAllPanels();
        gameoverPanel.SetActive(true);
        InputConstraintOverHUD.OnFilterNeeded?.Invoke();
    }
    private void ActivateLoading()
    {
        DisableAllPanels();
        loadingPanel.SetActive(true);
        InputConstraintOverHUD.OnFilterNeeded?.Invoke();
    }

    private void AutoStartGame()
    {
        AutoStartGame asg = menuPanel.AddComponent<AutoStartGame>();
        asg.menuHUD = menuPanel.GetComponent<MainMenuHUD>();
    }

}
