using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel, pausePanel, loadingPanel, gameloopPanel, gameoverPanel;
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
    }
    private void ActivateMainMenu()
    {
        DisableAllPanels();
        menuPanel.SetActive(true);
    }
    private void AcivatePause()
    {
        DisableAllPanels();
        pausePanel.SetActive(true);
    }
    private void ActivateGameLoop()
    {
        DisableAllPanels();
        gameloopPanel.SetActive(true);
    }
    private void ActivateGameOver()
    {
        DisableAllPanels();
        gameoverPanel.SetActive(true);
    }
    private void ActivateLoading()
    {
        DisableAllPanels();
        loadingPanel.SetActive(true);
    }

    private void AutoStartGame()
    {
        AutoStartGame asg = menuPanel.AddComponent<AutoStartGame>();
        asg.menuHUD = menuPanel.GetComponent<MainMenuHUD>();
    }

}
