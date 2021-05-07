using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour
{
    public static System.Action PointsUpdated;

    private void OnEnable()
    {
        WallBehaviour.PassedCorrectly += WallPassed;

        StateManager.OnPlay += Initialize;
        StateManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        WallBehaviour.PassedCorrectly -= WallPassed;

        StateManager.OnPlay -= Initialize;
        StateManager.OnGameOver -= GameOver;
    }


    // if not initialized yet, this should prepare progression variables for a fully new game sessione
    private void Initialize()
    {
        if (!StateManager.isInitialized)
        {
            DifficultyManager.Initialize();
            ScoreManager.Initialize();
        }
    }

    // triggered by "Player Success"
    private void WallPassed()
    {
        if (StateManager.GetGameState == GameState.playing)
        {
            if (!gameObject.GetComponent<InitialPawnBooster>())
            {

                ScoreManager.AddPoints();

                PointsUpdated?.Invoke();

                if (GamePlayCounters.actualSpeed <= 20)
                {
                    DifficultyManager.IncreaseActualSpeed();
                    if (GamePlayCounters.actualChunkDistance < 3)
                        DifficultyManager.IncreaseChunkDistance();
                    Debug.Log("level 1");
                }
                if (GamePlayCounters.actualSpeed > 20 && GamePlayCounters.actualSpeed <= 40)
                {
                    DifficultyManager.IncreaseActualSpeed();
                    if (GamePlayCounters.actualChunkDistance < 4)
                    {
                        DifficultyManager.IncreaseActualSpeedMultiplier();
                        DifficultyManager.IncreaseChunkDistance();
                    }
                    Debug.Log("level 2");
                }
                if (GamePlayCounters.actualSpeed > 60 && GamePlayCounters.actualChunkDistance < 5)
                {
                    DifficultyManager.IncreaseChunkDistance();
                    DifficultyManager.EnableVerticalMovement();
                    Debug.Log("level 3");
                }

                Debug.Log(GamePlayCounters.actualSpeed);
            }
        }
    }

    // triggered by "Player Error"
    private void GameOver()
    {
        if (StateManager.isInitialized)
        {
            if (StateManager.GetGameState == GameState.gameOver)
            {
                ScoreManager.SaveScoring();
                ScoreManager.ResetCurrentScore();
                ScoreManager.ResetScoreMultiplier();

                PointsUpdated?.Invoke();
            }
            StateManager.UpdateState(GameState.reset);
        }
    }
}
