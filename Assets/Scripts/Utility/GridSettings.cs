using System.Collections.Generic;
using UnityEngine;

public class GridSettings : Singleton<GridSettings>
{
    // dimensions of the grids
    public int height { get => Height; private set => Height = value; }
    [SerializeField] private int Height = 4;
    public int width { get => Width; private set => Width = value; }
    [SerializeField] private int Width = 6;

    // number of prepared walls
    public int numberOfPreparedWalls { get => NumberOfPreparedWalls; private set => NumberOfPreparedWalls = value; }
    [SerializeField] private int NumberOfPreparedWalls = 4;

    // dimension of the cell of a grid
    public float cellSize { get => CellSize; private set => CellSize = value; }
    [SerializeField] private float CellSize = 1;

    // the player object will be the same throught all the game and will be the container for the player grid
    // the obstacle object will be different for each wall and will be the container for the obstacle grid
    public GameObject playerObject { get => PlayerObject; private set => PlayerObject = value; }
    [SerializeField] private GameObject PlayerObject;

    public GameObject obstacleObject { get => ObstacleObject; private set => ObstacleObject = value; }
    [SerializeField] private GameObject ObstacleObject;


    // the hollow brick is the empty trigger and the blocking brick is the object that must not be touched.
    public GameObject hollowBrick { get => HollowBrick; private set => HollowBrick = value; }
    [SerializeField] private GameObject HollowBrick;

    public GameObject blockingBrick { get => BlockingBrick; private set => BlockingBrick = value; }
    [SerializeField] private GameObject BlockingBrick;


    // the active shape is the pawn in use for this round and the wall shape is the shape used to made the incoming wall
    [HideInInspector] public GameObject activeShape;
    [HideInInspector] public GameObject wallShape;

    // these two grids are made to contain and adjust position of tetrimini and wall items
    [HideInInspector] public TiledGrid<TetriminoGridItem> playerGrid;
    [HideInInspector] public TiledGrid<TetriminoGridItem> obstacleGrid;

    // Queue for Shapes and Prepared Walls
    [HideInInspector] public Queue<GameObject> queuedShapes = new Queue<GameObject>();
    [HideInInspector] public Queue<GameObject> wallQueue = new Queue<GameObject>();

    // the array of different shapes
    public GameObject[] shapes { get => Shapes; private set => Shapes = value; }
    [SerializeField] private GameObject[] Shapes;
}