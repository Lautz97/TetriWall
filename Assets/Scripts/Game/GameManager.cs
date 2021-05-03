﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    private Vector3 NextTileSpawn = Vector3.zero;
    [SerializeField] private GameObject chunk;
    [SerializeField] private int ClusterDimension;
    private Transform cluster;
    [SerializeField] private PawnBehaviour pawnBehaviour;

    private int chunkDistance = 3, chunkRemaining = int.MaxValue;

    private void OnEnable()
    {
        ChunkBehaviour.EndTileTriggered += SpawnNextTile;

        WallBehaviour.PassedCorrectly += PassedWallTriggered;
        WallBehaviour.PassedWrongly += HitWallTriggered;

        SwipeDetector.OnSwipe += SwipeDetected;

        StateManager.OnGameLoopStart += StartPlaying;
    }
    private void OnDisable()
    {
        ChunkBehaviour.EndTileTriggered -= SpawnNextTile;

        WallBehaviour.PassedCorrectly -= PassedWallTriggered;
        WallBehaviour.PassedWrongly -= HitWallTriggered;

        SwipeDetector.OnSwipe -= SwipeDetected;

        StateManager.OnGameLoopStart -= StartPlaying;

    }

    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
    }

    void InitLevel()
    {
        cluster = new GameObject("cluster").transform;

        cluster.position = Vector3.zero;
        cluster.rotation = Quaternion.identity;
        cluster.localScale = Vector3.one;

        for (int i = 0; i < ClusterDimension; i++)
        {
            SpawnNextTile();
        }
        /*Spawn first 20 chunks*/
    }

    void StartPlaying()
    {
        chunkRemaining = 0;
        InitPlayer();
    }

    void InitPlayer()
    {
        StartCoroutine(SpawnNextPawn());
    }

    public void PassedWallTriggered()
    {
        ProgressionManager.Instance.WallPassed();
        InitPlayer();
    }
    public void HitWallTriggered()
    {
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }

    public void SpawnNextTile()
    {
        GameObject spawnedChunk = Instantiate(chunk, NextTileSpawn, Quaternion.identity, cluster);
        NextTileSpawn = spawnedChunk.GetComponent<ChunkBehaviour>().NextSpawnPoint;
        if (chunkRemaining > 0) chunkRemaining--;
        else
        {
            chunkRemaining = chunkDistance;
            GridManager.Instance.ActivateWall(spawnedChunk.transform);
        }
    }

    public IEnumerator SpawnNextPawn()
    {
        yield return new WaitForSeconds(0.5f);
        GridManager.Instance.InstanciateNextPawn();
    }

    void SwipeDetected(SwipeData sw)
    {
        if (sw.Direction == Vector2.zero)
        {
            RotatePawn();
        }
        else
        {
            MovePawn(sw.Direction);
        }
    }

    private void MovePawn(Vector2 where)
    {
        GridManager.Instance.MoveActive(where);
    }
    private void RotatePawn()
    {
        GridManager.Instance.RotateActive();
    }

}
