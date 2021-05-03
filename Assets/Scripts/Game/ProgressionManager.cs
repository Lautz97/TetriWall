using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : Singleton<ProgressionManager>
{
    public static System.Action PointsUpdated;

    [SerializeField] private int currentPoints = 0, wallPoints = 1, pointsMultiplier = 1;

    [SerializeField] private float startingSpeed = 15, deltaSpeed = 0.1f, startingSpeedMultiplier = 1;

    private void OnEnable()
    {
        WallBehaviour.PassedCorrectly += WallPassed;
    }

    private void OnDisable()
    {
        WallBehaviour.PassedCorrectly -= WallPassed;
    }


    private void Start()
    {
        PawnBehaviour.Instance.speed = startingSpeed;
        PawnBehaviour.Instance.speedMultiplier = startingSpeedMultiplier;

        ResetScoring();

        PointsUpdated?.Invoke();
    }

    private void WallPassed()
    {
        PawnBehaviour.Instance.speed += deltaSpeed;

        AddPoints();

        PointsUpdated?.Invoke();
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

    }

    private void ResetScoring()
    {
        currentPoints = 0;
        SaveScoring();
    }

    private void SaveScoring()
    {
        SaveLoad.SaveCurrentScore(currentPoints);
    }
}
