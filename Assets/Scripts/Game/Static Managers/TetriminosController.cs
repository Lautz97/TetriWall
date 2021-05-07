using UnityEngine;

public static class TetriminosController
{
    // adjustment variable to regulate I piece movement.... BUGGY LONG STICK

    public static void MoveActive(Vector2 where) { if (GridSettings.Instance.activeShape != null) MoveObject(where, GridSettings.Instance.activeShape); }

    public static void RotateActive() { if (GridSettings.Instance.activeShape != null) RotateObject(GridSettings.Instance.activeShape); }


    public static void MoveWallPlaceholder(Vector2 where) { if (GridSettings.Instance.wallShape != null) MoveObject(where, GridSettings.Instance.wallShape); }
    public static void RotateWallPlaceholder() { if (GridSettings.Instance.wallShape != null) RotateObject(GridSettings.Instance.wallShape); }


    #region MoveStuffAroundGenerics~~
    private static void MoveObject(Vector2 where, GameObject who)
    {
        Vector3 w = where * GridSettings.Instance.cellSize;
        who.transform.localPosition += w;
        if (!GridManager.ValidPosition(who.transform, out Vector2 error))
        {
            who.transform.localPosition -= w;
        }
    }

    private static bool flipI = true;
    private static void RotateObject(GameObject who)
    {
        if (who.name != "Q")
        {
            if (who.name == "I") //I is a bit BUGGY
            {
                who.transform.RotateAround(who.transform.GetChild(4).position, Vector3.forward, 90 * (flipI ? 1 : -1));
                flipI = !flipI;
                if (!GridManager.ValidPosition(who.transform, out Vector2 error))
                {
                    if (error == Vector2.up || error == Vector2.right)
                    {
                        MoveObject(-error, who);
                        if (!GridManager.ValidPosition(who.transform, out error))
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
                if (!GridManager.ValidPosition(who.transform, out Vector2 error))
                {
                    MoveObject(-error, who);
                }
            }
            if (GamePlaySettings.onlyHorizontal) MoveObject(Vector2.down, who);
        }
    }

    #endregion
}
