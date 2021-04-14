using UnityEngine;
public class TetriminoGridItem
{
    private readonly int x, y;
    private GameObject value;
    private readonly TiledGrid<TetriminoGridItem> grid;

    public TetriminoGridItem(TiledGrid<TetriminoGridItem> g, int x, int y, GameObject value = null)
    {
        this.grid = g; this.x = x; this.y = y; this.value = value;
    }
    public void SetValue(GameObject value)
    {
        this.value = value;
        grid.TriggetObjectChanged(this.x, this.y);
    }
    public GameObject GetValue()
    {
        return value;
    }
    public override string ToString()
    {
        return x + "," + y;
    }
}