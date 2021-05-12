using UnityEngine;
using TMPro;

public class GameLoopHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text currentScoreText, hiScoreText;

    private void OnEnable()
    {
        ProgressionManager.PointsUpdated += UpdatePoints;

        UpdatePoints();
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

    public void Pause()
    {
        StateManager.Pause();
    }
}
