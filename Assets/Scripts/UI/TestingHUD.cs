using UnityEngine;
using TMPro;


public class TestingHUD : MonoBehaviour
{
    public TMP_Text minSwipeText, contInputText, onlyHorizontalText;

    public GameObject testingPanel;

    private void OnEnable()
    {
        testingPanel.SetActive(true);
        minSwipeText.text = InputSettings.minSwipeDistance.ToString();
        contInputText.text = (!InputSettings.detectOnlyAfterRelease).ToString();
        onlyHorizontalText.text = (GamePlaySettings.onlyHorizontal).ToString();
    }
    private void OnDisable()
    {
        testingPanel.SetActive(false);
    }
    public void UpdateMinSwipeDistance(float delta)
    {
        InputSettings.minSwipeDistance += delta;
        minSwipeText.text = InputSettings.minSwipeDistance.ToString();
    }

    public void UpdateContinuousDetection()
    {
        InputSettings.detectOnlyAfterRelease = !InputSettings.detectOnlyAfterRelease;
        contInputText.text = (!InputSettings.detectOnlyAfterRelease).ToString();
    }

    public void UpdateOnlyHorizontal()
    {
        GamePlaySettings.onlyHorizontal = !GamePlaySettings.onlyHorizontal;
        onlyHorizontalText.text = (GamePlaySettings.onlyHorizontal).ToString();
    }

}
