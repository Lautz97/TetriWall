using UnityEngine;

public class GameInstancesManager : MonoBehaviour
{
    private void OnEnable()
    {
        WallBehaviour.PassedCorrectly += RemoveActiveShapeControl;
        WallBehaviour.PassedWrongly += RemoveActiveShapeControl;
    }

    private void OnDisable()
    {
        WallBehaviour.PassedCorrectly -= RemoveActiveShapeControl;
        WallBehaviour.PassedWrongly -= RemoveActiveShapeControl;
    }

    private void Awake()
    {
        GridManager.InitializeGrids();
        GenerateQueuePadding();
    }


    private void GenerateQueuePadding()
    {
        for (int i = 0; i < GridSettings.Instance.numberOfPreparedWalls; i++)
        {
            QueueManager.EnqueueNewPair();
        }
    }

    // given a chunk the first wall in the queue is attached to it and set to active
    // then a new pair wall/shape is queued
    //TODO this is non changing with the cellsize
    public static void ActivateWall(Transform chunk)
    {
        GameObject c = QueueManager.DeQueueNextWall();
        c.transform.parent = chunk;
        c.transform.localPosition = new Vector3(c.transform.position.x, c.transform.position.y, -300);
        c.SetActive(true);
        QueueManager.EnqueueNewPair();
    }

    /**
    *** This method will take from the queue the next active shape
    *** and will set it as active
    /// TODO still impling that if a pool is present the object must not be initialized
    */
    public static void InstanciateNextPawn()
    {
        GridSettings.Instance.activeShape = InstanciatePawnBrick(QueueManager.DeQueueNextPawn(), Vector2.zero);
        GridSettings.Instance.activeShape.transform.localPosition = new Vector3(GridSettings.Instance.activeShape.transform.localPosition.x, GridSettings.Instance.activeShape.transform.localPosition.y, 0);
        GridSettings.Instance.activeShape.SetActive(true);
    }

    /**
    *** The active shape became null
    /// TODO still impling that if a pool is present the object must not be destroyed
    */
    private static void RemoveActiveShapeControl()
    {
        GridSettings.Instance.activeShape = null;
    }


    public static GameObject InstanciateWallBrick(GameObject container, GameObject spawnable, Vector2 position) => InstanciateBrick(GridSettings.Instance.obstacleGrid, container, spawnable, position);

    public static GameObject InstanciatePawnBrick(GameObject spawnable, Vector2 position) => InstanciateBrick(GridSettings.Instance.playerGrid, GridSettings.Instance.playerObject, spawnable, position);


    // instanciate game object in a grid given a position
    /// TODO if a pool is present the object must not be initialized
    private static GameObject InstanciateBrick(TiledGrid<TetriminoGridItem> grid, GameObject gridParent, GameObject spawnable, Vector2 position)
    {
        grid.GetGridPosition(position + Vector2.one * 0.1f, out int x, out int y);

        GameObject ret = MonoBehaviour.Instantiate(spawnable, grid.GetWorldPosition(x, y), Quaternion.identity);

        ret.name = spawnable.name;
        ret.transform.parent = gridParent.transform;
        ret.transform.localScale = Vector3.one;

        return ret;
    }

    public static GameObject NewGameObject(string name) { return new GameObject(name); }

}
