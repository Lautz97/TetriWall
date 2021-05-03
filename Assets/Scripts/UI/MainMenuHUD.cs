using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHUD : MonoBehaviour
{
    public void Play()
    {
        StateManager.UpdateState(GameState.playing);
    }

}
