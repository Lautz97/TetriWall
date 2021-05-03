using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : Singleton<ProgressionManager>
{
    public static System.Action PointsUpdated;

    [SerializeField] private int currentPoints = 0, wallPoints = 1, pointsMultiplier = 1;

    [SerializeField] private float startingSpeed = 15, deltaSpeed = 0.1f, startingSpeedMultiplier = 1;

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


    private void Initialize()
    {
        if (!StateManager.isInitialized)
        {
            PawnBehaviour.Instance.speed = startingSpeed;
            PawnBehaviour.Instance.speedMultiplier = startingSpeedMultiplier;

            ResetScoring();

            PointsUpdated?.Invoke();
        }
    }

    private void ResetScoring()
    {
        currentPoints = 0;
        SaveScoring();
    }

    private void WallPassed()
    {
        if (StateManager.GetGameState == GameState.playing)
        {
            PawnBehaviour.Instance.speed += deltaSpeed;

            AddPoints();

            PointsUpdated?.Invoke();
        }
    }

    private void AddPoints()
    {
        currentPoints += wallPoints * pointsMultiplier;
        SaveScoring();
    }

    private void SetMultiplier()
    {

    }

    private void GameOver()
    {
        if (StateManager.isInitialized)
        {
            if (StateManager.GetGameState == GameState.gameOver)
            {
                SaveScoring();
                ResetScoring();

                PointsUpdated?.Invoke();
            }
            SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
        }
    }

    private void SaveScoring()
    {
        SaveLoad.SaveCurrentScore(currentPoints);
        SaveLoad.SaveHiScore(currentPoints);
    }
}
