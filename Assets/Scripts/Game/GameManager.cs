using System.Collections;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    private Vector3 NextTileSpawn = Vector3.zero;
    [SerializeField] private GameObject chunk;
    [SerializeField] private int ClusterDimension;
    private Transform cluster;
    [SerializeField] private PawnBehaviour pawnBehaviour;

    private int chunkDistance = 3, chunkRemaining = 999999;

    private void OnEnable()
    {
        ChunkBehaviour.EndTileTriggered += SpawnNextTile;
        WallBehaviour.PassedCorrectly += PassedWallTriggered;
        WallBehaviour.PassedWrongly += HitWallTriggered;
        SwipeDetector.OnSwipe += SwipeDetected;

        StateManager.OnPlay += StartSession;
    }
    private void OnDisable()
    {
        ChunkBehaviour.EndTileTriggered -= SpawnNextTile;
        WallBehaviour.PassedCorrectly -= PassedWallTriggered;
        WallBehaviour.PassedWrongly -= HitWallTriggered;
        SwipeDetector.OnSwipe -= SwipeDetected;

        StateManager.OnPlay -= StartSession;
    }

    // Start is called before the first frame update
    private void Start()
    {
        cluster = new GameObject("cluster").transform;

        cluster.position = Vector3.zero;
        cluster.rotation = Quaternion.identity;
        cluster.localScale = Vector3.one;

        /*Spawn first 20 chunks*/
        InitStartingCluster();
    }

    private void InitStartingCluster()
    {
        for (int i = 0; i < ClusterDimension; i++)
        {
            SpawnNextTile();
        }
    }

    private void StartSession()
    {
        if (!StateManager.isInitialized)
        {
            chunkRemaining = 0;
            NextPawn();
        }
    }

    private void NextPawn()
    {
        StartCoroutine(SpawnNextPawn());
    }

    private void PassedWallTriggered()
    {
        NextPawn();
    }
    private void HitWallTriggered()
    {
        StateManager.UpdateState(GameState.gameOver);
    }

    private void SpawnNextTile()
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

    private IEnumerator SpawnNextPawn()
    {
        yield return new WaitForSeconds(0.5f);
        GridManager.Instance.InstanciateNextPawn();
    }

    private void SwipeDetected(SwipeData sw)
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
