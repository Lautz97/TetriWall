using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : Singleton<ProgressionManager>
{

    [SerializeField] private int currentPoints = 0, wallPoints = 1, pointsMultiplier = 1;

    [SerializeField] private float startingSpeed = 15, deltaSpeed = 0.1f, startingSpeedMultiplier = 1;

    private void Start()
    {
        PawnBehaviour.Instance.speed = startingSpeed;
        PawnBehaviour.Instance.speedMultiplier = startingSpeedMultiplier;
        UIManager.Instance.UpdatePoints(currentPoints);
    }

    public void WallPassed()
    {
        currentPoints += wallPoints * pointsMultiplier;
        UIManager.Instance.UpdatePoints(currentPoints);
        PawnBehaviour.Instance.speed += deltaSpeed;
    }

    public void SetMultiplier()
    {

    }

    public void GameOver()
    {

    }
}
