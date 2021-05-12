using UnityEngine;

public class PauseHUD : MonoBehaviour
{
    public void ResumeGame()
    {
        StateManager.Resume();
    }

    public void QuitToMenu()
    {
        //TODO FIX THIS
        StateManager.Reset();
    }

    public void QuitGame()
    {
        // DONE for now
        // se il gioco viene chiuso dal menu di pausa
        // non far perdere i progressi al giocatore
        // salvare punteggi etc
        StateManager.Quit();
    }

    public void TestMenu()
    {
        gameObject.GetComponent<TestingHUD>().enabled = !gameObject.GetComponent<TestingHUD>().enabled;
    }

}
