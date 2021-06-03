using UnityEngine;

public class AutoStartGame : MonoBehaviour
{
    public MainMenuHUD menuHUD;

    private void Update()
    {
        menuHUD.Play();
        DestroyImmediate(this);
    }
}
