using UnityEngine;

public class MainMenuHUD : MonoBehaviour
{
    public void Play()
    {
        StateManager.Initialize();
    }

    public void Quit()
    {
        StateManager.Quit();
    }


    [SerializeField] GameObject SettingsPanel;
    public void Settings()
    {
        SettingsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

}
