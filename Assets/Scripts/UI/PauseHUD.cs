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
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
        //TODO FIX THIS
        // StateManager.UpdateState(GameState.mainMenu);
    }

}
