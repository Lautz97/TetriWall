using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text text;

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
        int points = SaveLoad.LoadCurrentScore();
        text.text = "Points: " + points;
    }

}
