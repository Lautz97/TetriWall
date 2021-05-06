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


    // if not initialized yet, this should prepare progression variables for a fully new game sessione
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

    // triggered by "Player Success"
    private void WallPassed()
    {
        if (StateManager.GetGameState == GameState.playing)
        {
            if (!gameObject.GetComponent<InitialPawnBooster>())
            {

                AddPoints();

                PointsUpdated?.Invoke();

                if (PawnBehaviour.Instance.speed <= 40)
                {
                    PawnBehaviour.Instance.speed += deltaSpeed;
                    if (GamePlaySettings.chunkDistance != 3)
                        GamePlaySettings.chunkDistance = 3;
                }
                if (PawnBehaviour.Instance.speed > 40 && PawnBehaviour.Instance.speed <= 60)
                {
                    PawnBehaviour.Instance.speed += deltaSpeed * 2;
                    if (GamePlaySettings.chunkDistance != 4)
                        GamePlaySettings.chunkDistance = 4;
                }
                if (PawnBehaviour.Instance.speed > 60 && GamePlaySettings.chunkDistance != 5)
                {
                    if (GamePlaySettings.chunkDistance != 5)
                    {
                        GamePlaySettings.chunkDistance = 5;
                        GamePlaySettings.onlyHorizontal = false;
                    }
                }
            }
        }
    }

    // Add to current Points the just earned point quantity, counting also the multiplier
    private void AddPoints()
    {
        currentPoints += wallPoints * pointsMultiplier;
        SaveScoring();
    }

    // this will set the multiplier
    private void SetMultiplier()
    {

    }

    // triggered by "Player Error"
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
            StateManager.UpdateState(GameState.reset);
        }
    }

    // Saves both current and highest score, and possibly also the other variables.
    // player may continue even if closed the game by error.
    private void SaveScoring()
    {
        SaveLoad.SaveCurrentScore(currentPoints);
        SaveLoad.SaveHiScore(currentPoints);
    }

    // method for resetting current score
    private void ResetScoring()
    {
        SaveLoad.ResetCurrentScore();
        currentPoints = SaveLoad.LoadCurrentScore();
    }
}
