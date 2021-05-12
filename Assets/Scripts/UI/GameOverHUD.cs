using TMPro;
using UnityEngine;

public class GameOverHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text currentScoreText, hiScoreText;

    private void OnEnable()
    {
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        currentScoreText.text = "Last Score: " + SaveLoad.LoadCurrentScore();
        hiScoreText.text = "Highest Score: " + SaveLoad.LoadHiScore();
    }

    public void Quit()
    {
        StateManager.Quit();
    }

    public void MainMenu()
    {
        StateManager.Reset();
    }

    public void PlayAgain()
    {
        print("GAME RESETTED BY GAME OVER HUD");
        print("THIS DOES NOT WORK PROPERLY");
        StateManager.Reset();
    }
}
