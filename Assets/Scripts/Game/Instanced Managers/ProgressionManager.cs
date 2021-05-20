using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour
{
    public static System.Action PointsUpdated;
    public static System.Action<int> OnLevelRaise;

    private int level = 0;

    private void OnEnable()
    {
        WallBehaviour.PassedCorrectly += WallPassed;

        StateManager.OnInitialize += Initialize;
        StateManager.OnGameOver += GameOver;
        StateManager.OnReset += ResetGame;
    }

    private void OnDisable()
    {
        WallBehaviour.PassedCorrectly -= WallPassed;

        StateManager.OnInitialize -= Initialize;
        StateManager.OnGameOver -= GameOver;
        StateManager.OnReset -= ResetGame;
    }


    // if not initialized yet, this should prepare progression variables for a fully new game sessione
    private void Initialize()
    {
        DifficultyManager.Initialize();
        ScoreManager.Initialize();
        level = 0;
    }

    // triggered by "Player Success"
    private void WallPassed()
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
            }

            // if (GamePlayCounters.actualSpeed > 20 - 5 * GamePlayCounters.actualDeltaSpeed)
            // {
            //     if (GamePlayCounters.actualChunkDistance < 4)
            //     {
            //         DifficultyManager.IncreaseChunkDistance();
            //     }
            // }
            if (GamePlayCounters.actualSpeed > 20 && GamePlayCounters.actualSpeed <= 30)
            {
                if (level < 1)
                {
                    level = 1;
                    DifficultyManager.IncreaseDeltaSpeedMultiplier();
                    OnLevelRaise?.Invoke(level);
                }
                DifficultyManager.IncreaseActualSpeed();
            }

            if (GamePlayCounters.actualSpeed > 30 - 5 * GamePlayCounters.actualDeltaSpeed)
            {
                if (GamePlayCounters.actualChunkDistance < 4)
                {
                    DifficultyManager.IncreaseChunkDistance();
                }
            }
            if (GamePlayCounters.actualSpeed > 30 && GamePlayCounters.actualSpeed <= 40)
            {
                if (level < 2)
                {
                    level = 2;
                    DifficultyManager.IncreaseDeltaSpeedMultiplier();
                    OnLevelRaise?.Invoke(level);
                }
                DifficultyManager.IncreaseActualSpeed();
            }

            if (GamePlayCounters.actualSpeed > 60 - 5 * GamePlayCounters.actualDeltaSpeed)
            {
                if (GamePlayCounters.actualChunkDistance < 5)
                {
                    DifficultyManager.IncreaseChunkDistance();
                }
            }
            if (GamePlayCounters.actualSpeed > 60)
            {
                if (level < 3)
                {
                    level = 3;
                    DifficultyManager.EnableVerticalMovement();
                    OnLevelRaise?.Invoke(level);
                }
            }
        }
    }

    // triggered by "Player Error"
    private void GameOver()
    {
        ScoreManager.SaveScoring();

        PointsUpdated?.Invoke();
    }

    private void ResetGame()
    {
        ScoreManager.ResetCurrentScore();
        ScoreManager.ResetScoreMultiplier();
    }
}
