using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text text;

    private void OnEnable()
    {
        ProgressionManager.PointsUpdated += UpdatePoints;
    }
    private void OnDisable()
    {
        ProgressionManager.PointsUpdated -= UpdatePoints;
    }

    public void UpdatePoints(int points)
    {
        text.text = "Points: " + points;
    }

}
