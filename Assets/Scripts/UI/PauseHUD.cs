using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHUD : MonoBehaviour
{
    public void ResumeGame()
    {
        StateManager.UpdateState(GameState.playing);
    }

    public void QuitToMenu()
    {
        //TODO FIX THIS
        StateManager.UpdateState(GameState.reset);
    }

    public void TestMenu()
    {
        gameObject.GetComponent<TestingHUD>().enabled = !gameObject.GetComponent<TestingHUD>().enabled;
    }

}
