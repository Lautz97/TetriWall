using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    // this will make tetrimini slide down every time they rotate
    private bool gravity = true;

    // dimensions of the grids
    public int width, height;

    // dimension of the cell of a grid
    public float cellSize;

    // these two grids are made to contain and adjust position of tetrimini and wall items
    private TiledGrid<TetriminoGridItem> playerGrid, obstacleGrid;

    // the player object will be the same throught all the game and will be the container for the player grid
    // the obstacle object will be different for each wall and will be the container for the obstacle grid
    [SerializeField] private GameObject playerObject, obstacleObject;

    // the hollow brick is the empty trigger and the blocking brick is the object that must not be touched.
    [SerializeField] private GameObject hollowBrick, blockingBrick;

    // the array of different shapes
    [SerializeField] private GameObject[] shapes;

    // adjustment variable to regulate I piece movement.... BUGGY LONG STICK
    private bool flipI = true;

    // the active shape is the pawn in use for this round and the wall shape is the shape used to made the incoming wall
    private GameObject activeShape, wallShape;

    // should make a stack for shapes?
    private Queue<GameObject> queuedShapes, queuedWalls;

    // Start is called before the first frame update
    private void Start()
    {
        MakePlayerGrid();
        InstanciatePawn();
    }


    public void SetGeneric(GameObject playerContainer, bool gravity = true, int width = 6, int height = 4, float cellSize = 0.9f)
    {
        this.gravity = gravity;
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
    }


    // for each wall must be selected a container, created in a chunk object
    // this will create the full wall --entry point of this part of the script for wall gen
    public void SetNewObstacle(GameObject obstacleContainer)
    {
        obstacleObject = obstacleContainer;
        InstanciateWallPlaceholder();
    }





    public void InstanciatePawn()
    {
        activeShape = InstanciateBrick(playerGrid, playerObject, shapes[Random.Range(0, shapes.Length)], Vector2.zero);
    }

    private void InstanciateWallPlaceholder()
    {
        wallShape = InstanciateBrick(obstacleGrid, obstacleObject, shapes[Random.Range(0, shapes.Length)], Vector2.zero);
    }

    private GameObject InstanciateBrick(TiledGrid<TetriminoGridItem> grid, GameObject gridParent, GameObject spawnable, Vector2 position)
    {
        grid.GetGridPosition(position, out int x, out int y);

        GameObject ret = Instantiate(spawnable, grid.GetWorldPosition(x, y), Quaternion.identity);

        ret.name = spawnable.name;
        ret.transform.parent = gridParent.transform;
        ret.transform.localScale = Vector3.one;
        return ret;
    }





    public void MakePlayerGrid()
    {
        playerGrid = new TiledGrid<TetriminoGridItem>(playerObject.transform, height, width, cellSize, playerObject.transform, (TiledGrid<TetriminoGridItem> g, int x, int y) => new TetriminoGridItem(g, x, y));
    }

    public void MakeObstacleGrid()
    {
        obstacleGrid = new TiledGrid<TetriminoGridItem>(obstacleObject.transform, height, width, cellSize, obstacleObject.transform, (TiledGrid<TetriminoGridItem> g, int x, int y) => new TetriminoGridItem(g, x, y));
    }




    public void MoveActive(Vector2 where)
    {
        MoveObject(where, activeShape);
    }
    public void MoveWallPlaceholder(Vector2 where)
    {
        MoveObject(where, wallShape);
    }

    private void MoveObject(Vector2 where, GameObject who)
    {
        Vector3 w = where * transform.localScale;
        who.transform.localPosition += w;
        if (!ValidPosition(who.transform, out Vector2 error))
        {
            who.transform.localPosition -= w;
        }
    }



    public void RotateActive()
    {
        RotateObject(activeShape);
    }
    public void RotateWallPlaceholder()
    {
        RotateObject(wallShape);
    }

    private void RotateObject(GameObject who)
    {
        if (who.name != "Q")
        {
            if (who.name == "I") //I is a bit BUGGY
            {
                who.transform.RotateAround(who.transform.GetChild(4).position, Vector3.forward, 90 * (flipI ? 1 : -1));
                flipI = !flipI;
                if (!ValidPosition(who.transform, out Vector2 error))
                {
                    if (error == Vector2.up || error == Vector2.right)
                    {
                        MoveObject(-error, who);
                        if (!ValidPosition(who.transform, out error))
                        {
                            if (error == Vector2.up || error == Vector2.right)
                            {
                                MoveObject(-error, who);
                            }
                        }
                    }
                    else
                    {
                        MoveObject(-error, who);
                    }
                    // who.transform.RotateAround(who.transform.GetChild(4).position, Vector3.forward, 90);
                    // flipI = !flipI;
                }
            }
            else
            {
                who.transform.RotateAround(who.transform.GetChild(4).position, Vector3.forward, 90);
                if (!ValidPosition(who.transform, out Vector2 error))
                {
                    MoveObject(-error, who);
                }
            }
            if (gravity) MoveObject(Vector2.down, who);
        }
    }



    // if the transform is in a valid position return true
    // if not return an error vector issuing in which direction the error is
    private bool ValidPosition(Transform tetrimino, out Vector2 error)
    {
        bool ret = true;
        error = Vector2.zero;

        foreach (Transform child in tetrimino)
        {
            playerGrid.GetGridPosition(child.position, out int x, out int y);
            if (x < 0)
            {
                error.x = Vector2.left.x;
                ret = false;
            }
            else if (x > width - 1)
            {
                error.x = Vector2.right.x;
                ret = false;
            }
            if (y < 0)
            {
                error.y = Vector2.down.y;
                ret = false;
            }
            else if (y > height - 1)
            {
                error.y = Vector2.up.y;
                ret = false;
            }
        }
        return ret;
    }


    // private void LoadToGrid(TiledGrid<TetriminoGridItem> grid)
    // {
    //     foreach (Transform child in activeShape.transform)
    //     {
    //         pg.GetGridPosition(child.position, out int x, out int y);
    //         if (x < 0 || x > w - 1 || y < 0 || y > h - 1)
    //         {

    //         }
    //         else
    //         {
    //             grid.GetGridItem(child.transform.position).SetValue(child.gameObject);
    //         }
    //     }
    // }

    // private void UnloadFromGrid(TiledGrid<TetriminoGridItem> grid)
    // {
    //     foreach (Transform child in activeShape.transform)
    //     {
    //         pg.GetGridPosition(child.position, out int x, out int y);
    //         if (x < 0 || x > w - 1 || y < 0 || y > h - 1)
    //         {

    //         }
    //         else
    //         {
    //             grid.GetGridItem(child.transform.position).SetValue(null);
    //         }
    //     }
    // }
}
