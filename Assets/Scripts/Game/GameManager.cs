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

    private int chunkDistance = 3, chunkRemaining = 999999;

    // Start is called before the first frame update
    void Start()
    {
        cluster = new GameObject("cluster").transform;

        cluster.position = Vector3.zero;
        cluster.rotation = Quaternion.identity;
        cluster.localScale = Vector3.one;

        chunkRemaining = ClusterDimension - ClusterDimension / 2;

        for (int i = 0; i < ClusterDimension; i++)
        {
            SpawnNextTile();
        }
        /*Spawn first 20 chunks*/
        StartCoroutine(SpawnNextPawn());
    }

    public void EndTileTriggered()
    {
        SpawnNextTile();
    }

    public void PassedWallTriggered(Transform chunk)
    {
        GridManager.Instance.RemoveActiveShapeControl(chunk);
        ProgressionManager.Instance.WallPassed();
        StartCoroutine(SpawnNextPawn());
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

    public void MovePawn(Vector2 where)
    {
        GridManager.Instance.MoveActive(where);
    }
    public void RotatePawn()
    {
        GridManager.Instance.RotateActive();
    }

}
