using UnityEngine;
using UnityEngine.UI;

public class TutorialHUD : MonoBehaviour
{

    public static System.Action OnTutorialStart, OnTutorialEnd;

    [SerializeField] private GameObject tutorialToggleObj;
    private Toggle tutorialToggle;

    private void OnEnable()
    {
        tutorialToggle = tutorialToggleObj.GetComponent<Toggle>();
        OnTutorialStart?.Invoke();
        ToggleCheck();
        SettingsManager.OnTutorialChanged += ToggleCheck;
    }
    private void OnDisable()
    {
        SettingsManager.OnTutorialChanged -= ToggleCheck;
    }

    public void ExitTutorial()
    {
        OnTutorialEnd?.Invoke();
        gameObject.SetActive(false);
    }

    public void ToggleTutorial()
    {
        if (!protectedBool) SettingsManager.OnTutorialChangeRequest?.Invoke();
    }

    bool protectedBool = false;

    private void ToggleCheck()
    {
        protectedBool = true;
        tutorialToggle.isOn = GamePlaySettings.showTutorial;
        protectedBool = false;
    }

}
