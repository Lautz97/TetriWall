public class GenericGridItem
{
    private readonly int x, y;
    private int value;
    private readonly TiledGrid<GenericGridItem> grid;

    public GenericGridItem(TiledGrid<GenericGridItem> g, int x, int y, int value = default)
    {
        this.grid = g; this.x = x; this.y = y; this.value = value;
    }

    public void SetValue(int value)
    {
        this.value = value;
        grid.TriggetObjectChanged(this.x, this.y);
    }
    public void IncrementValue(int value)
    {
        this.value += value;
        grid.TriggetObjectChanged(this.x, this.y);
    }

    public int GetValue()
    {
        return value;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}