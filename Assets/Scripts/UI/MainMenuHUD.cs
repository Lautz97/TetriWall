using UnityEngine;

public class MainMenuHUD : MonoBehaviour
{
    public void Play()
    {
        StateManager.Initialize();
    }

    public void Quit(){
        StateManager.Quit();
    }

}
