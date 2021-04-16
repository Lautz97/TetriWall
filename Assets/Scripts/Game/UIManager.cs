using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text text;

    public void UpdatePoints(int points)
    {
        text.text = "Points: " + points;
    }

}
