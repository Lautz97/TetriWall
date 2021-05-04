using UnityEngine;
using TMPro;


public class TestingHUD : MonoBehaviour
{
    public TMP_Text minSwipeText, contInputText, onlyHorizontalText;

    public GameObject testingPanel;

    private void OnEnable()
    {
        testingPanel.SetActive(true);
        minSwipeText.text = Utils.minSwipeDistance.ToString();
        contInputText.text = (!Utils.detectOnlyAfterRelease).ToString();
        onlyHorizontalText.text = (Utils.onlyHorizontal).ToString();
    }
    private void OnDisable()
    {
        testingPanel.SetActive(false);
    }
    public void UpdateMinSwipeDistance(float delta)
    {
        Utils.minSwipeDistance += delta;
        minSwipeText.text = Utils.minSwipeDistance.ToString();
    }

    public void UpdateContinuousDetection()
    {
        Utils.detectOnlyAfterRelease = !Utils.detectOnlyAfterRelease;
        contInputText.text = (!Utils.detectOnlyAfterRelease).ToString();
    }

    public void UpdateOnlyHorizontal()
    {
        Utils.onlyHorizontal = !Utils.onlyHorizontal;
        onlyHorizontalText.text = (Utils.onlyHorizontal).ToString();
    }

}
