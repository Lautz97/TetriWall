using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private GameObject menuPanel, loadingPanel, gameloopPanel, gameOverPanel, pausePanel;

    private void OnEnable()
    {
        ProgressionManager.PointsUpdated += UpdatePoints;
        StateManager.OnGameLoopStart += SetGameLoopHud;
        StateManager.OnGameOver += SetGameOverHud;
        StateManager.OnMainMenu += SetMenuHud;
        StateManager.OnPaused += SetPauseHud;
        StateManager.OnLoading += SetLoading;
    }
    private void OnDisable()
    {
        ProgressionManager.PointsUpdated -= UpdatePoints;
        StateManager.OnGameLoopStart -= SetGameLoopHud;
        StateManager.OnGameOver -= SetGameOverHud;
        StateManager.OnMainMenu -= SetMenuHud;
        StateManager.OnPaused -= SetPauseHud;
        StateManager.OnLoading -= SetLoading;
    }

    private void UpdatePoints(int points)
    {
        if (StateManager.gameState == GameState.gameLoop)
            text.text = "Points: " + points;
    }
    private void DisableAll()
    {
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
        }
    }
    private void SetLoading()
    {
        DisableAll();
        loadingPanel.SetActive(true);
    }
    private void SetMenuHud()
    {
        DisableAll();
        menuPanel.SetActive(true);
    }
    private void SetGameLoopHud()
    {
        DisableAll();
        gameloopPanel.SetActive(true);
    }
    private void SetPauseHud()
    {
        DisableAll();
        pausePanel.SetActive(true);
    }
    private void SetGameOverHud()
    {
        DisableAll();
        pausePanel.SetActive(true);
    }



}
