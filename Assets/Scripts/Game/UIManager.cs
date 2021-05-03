using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text currentScoreText, hiScoreText;
    [SerializeField] private GameObject menuPanel, pausePanel, loadingPanel, gameloopPanel, gameoverPanel;

    private void Start()
    {
        UpdatePoints();
    }

    private void OnEnable()
    {
        ProgressionManager.PointsUpdated += UpdatePoints;
    }
    private void OnDisable()
    {
        ProgressionManager.PointsUpdated -= UpdatePoints;
    }

    private void UpdatePoints()
    {
        currentScoreText.text = "Points: " + SaveLoad.LoadCurrentScore();
        hiScoreText.text = "Best: " + SaveLoad.LoadHiScore();

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

}
