using UnityEngine;
using System.Collections;

public class TiledGridTest : MonoBehaviour
{
    public int w, h;
    public float cellSize;
    private TiledGrid<TetriminoGridItem> pg;
    [SerializeField] private GameObject po;

    // Start is called before the first frame update
    private void Start()
    {
        pg = new TiledGrid<TetriminoGridItem>(po.transform, h, w, cellSize, po.transform, (TiledGrid<TetriminoGridItem> g, int x, int y) => new TetriminoGridItem(g, x, y));
    }
}