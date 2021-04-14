using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void AddPoint()
    {
        Debug.Log("ui alive");
        text.text = (int.Parse(text.text) + 1).ToString();
    }

}
