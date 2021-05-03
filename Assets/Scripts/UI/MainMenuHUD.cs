using UnityEngine;

public class MainMenuHUD : MonoBehaviour
{
    public void Play()
    {
        StateManager.UpdateState(GameState.playing);
    }

}
