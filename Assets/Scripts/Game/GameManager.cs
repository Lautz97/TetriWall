using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    private Vector3 NextTileSpawn = Vector3.zero;
    [SerializeField] private GameObject chunk;
    [SerializeField] private int ClusterDimension;
    private Transform cluster;
    [SerializeField] private PawnBehaviour pawnBehaviour;

    // Start is called before the first frame update
    void Start()
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
        SpawnNextPawn();
    }

    public void EndTileTriggered()
    {
        SpawnNextTile();
    }

    public void SpawnNextTile()
    {
        NextTileSpawn = Instantiate(chunk, NextTileSpawn, Quaternion.identity, cluster).GetComponent<ChunkBehaviour>().NextSpawnPoint;
    }

    public void SpawnNextPawn()
    {
        // pawnBehaviour.SetActiveShape(shapes[UnityEngine.Random.Range(0, shapes.Length)]);
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
