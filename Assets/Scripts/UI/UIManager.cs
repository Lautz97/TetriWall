using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject menuPanel, pausePanel, loadingPanel, gameloopPanel, gameoverPanel;

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

}
