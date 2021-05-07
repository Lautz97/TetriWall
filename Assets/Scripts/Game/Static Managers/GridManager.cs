using UnityEngine;

public static class GridManager
{
    public static void InitializeGrids()
    {
        MakePlayerGrid();
        MakeObstacleGrid();
    }

    #region MakeGrids
    private static void MakePlayerGrid() =>
        GridSettings.Instance.playerGrid = new TiledGrid<TetriminoGridItem>(GridSettings.Instance.playerObject.transform,
                                                        GridSettings.Instance.height, GridSettings.Instance.width, GridSettings.Instance.cellSize,
                                                        GridSettings.Instance.playerObject.transform,
                                                        (TiledGrid<TetriminoGridItem> g, int x, int y) => new TetriminoGridItem(g, x, y));

    private static void MakeObstacleGrid() =>
        GridSettings.Instance.obstacleGrid = new TiledGrid<TetriminoGridItem>(GridSettings.Instance.obstacleObject.transform,
                                                        GridSettings.Instance.height, GridSettings.Instance.width, GridSettings.Instance.cellSize,
                                                        GridSettings.Instance.obstacleObject.transform,
                                                        (TiledGrid<TetriminoGridItem> g, int x, int y) => new TetriminoGridItem(g, x, y));
    #endregion

    // if the transform is in a valid position return true
    // if not return an error vector issuing in which direction the error is
    public static bool ValidPosition(Transform tetrimino, out Vector2 error)
    {
        bool ret = true;
        error = Vector2.zero;

        foreach (Transform child in tetrimino)
        {
            GridSettings.Instance.playerGrid.GetGridPosition(child.position, out int x, out int y);
            if (x < 0)
            {
                error.x = Vector2.left.x;
                ret = false;
            }
            else if (x > GridSettings.Instance.width - 1)
            {
                error.x = Vector2.right.x;
                ret = false;
            }
            if (y < 0)
            {
                error.y = Vector2.down.y;
                ret = false;
            }
            else if (y > GridSettings.Instance.height - 1)
            {
                error.y = Vector2.up.y;
                ret = false;
            }
        }
        return ret;
    }

}
