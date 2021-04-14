using System;
using UnityEngine;

public class TiledGrid<TGridObject>
{
    bool debug = true;

    /// <summary>
    /// quando viene cambiato un valore nella griglia
    /// </summary>
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;

    /// <summary>
    /// Argomenti che accompagnano un cambiamento nella griglia
    /// </summary>
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x, y;
    }

    //posizione d'origine della griglia
    private readonly Vector3 originPosition = default;

    //numero di celle in altezza e in larghezza
    private readonly int height = 1, width = 1;

    //dimenzione di un lato della cella
    private readonly float cellSize = 10f;

    //matrice della griglia
    private readonly TGridObject[,] cellGrid;

    //matrice degli oggetti di debug
    private readonly TextMesh[,] debugTextArray;

    /// <summary>
    /// inizializza una griglia secondo le specifiche inserite
    /// </summary>
    /// <param name="h"> default = 1 numero di celle in altezza </param>
    /// <param name="w"> default = 1 numero di celle in larghezza </param>
    /// <param name="cS"> default = 10f lunghezza lato cella </param>
    /// <param name="oP"> default = null transform origine griglia </param>
    public TiledGrid(Transform parent, int h = 1, int w = 1, float cS = 10f, Transform oP = null, Func<TiledGrid<TGridObject>, int, int, TGridObject> constructor = null)
    {
        parent.localPosition = new Vector3(-(w / 2) * cS, parent.localPosition.y, parent.localPosition.z);
        parent.localScale = Vector3.one * cS;

        if (oP != null) originPosition = oP.position;
        height = h; width = w; cellSize = cS;

        cellGrid = new TGridObject[width, height];

        for (int x = 0; x < cellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < cellGrid.GetLength(1); y++)
            {
                cellGrid[x, y] = constructor(this, x, y);
            }
        }

        if (debug)
        {
            debugTextArray = new TextMesh[width, height];
            GenerateDebugItemsGrid(parent);
        }
    }

    /// <summary>
    /// inizializza una griglia secondo le specifiche inserite
    /// </summary>
    /// <param name="h"> default = 1 numero di celle in altezza </param>
    /// <param name="w"> default = 1 numero di celle in larghezza </param>
    /// <param name="cS"> default = 10f lunghezza lato cella </param>
    /// <param name="oP"> default = null vector3 origine griglia </param>
    public TiledGrid(Transform parent, int h = 1, int w = 1, float cS = 10f, Vector3 oP = default, Func<TiledGrid<TGridObject>, int, int, TGridObject> constructor = null)
    {
        if (oP != null) originPosition = oP;
        height = h; width = w; cellSize = cS;

        cellGrid = new TGridObject[width, height];

        for (int x = 0; x < cellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < cellGrid.GetLength(1); y++)
            {
                cellGrid[x, y] = constructor(this, x, y);
            }
        }

        parent.localPosition = new Vector3(-(width / 2) * cellSize, parent.localPosition.y, parent.localPosition.z);
        parent.localScale = Vector3.one * cellSize;

        if (debug)
        {
            debugTextArray = new TextMesh[width, height];
            GenerateDebugItemsGrid(parent);
        }
    }

    /// <summary>
    /// genera una griglia di oggetti di debug
    /// </summary>
    private void GenerateDebugItemsGrid(Transform parent)
    {
        for (int x = 0; x < cellGrid.GetLength(0); x++)
        {
            for (int y = 0; y < cellGrid.GetLength(1); y++)
            {
                debugTextArray[x, y] = InstanciateDebugItems.CreateText(cellGrid[x, y].ToString(), parent,
                                                                        GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, 20,
                                                                        Color.white, TextAnchor.MiddleCenter).GetComponent<TextMesh>();

                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, cellGrid.GetLength(1)), GetWorldPosition(cellGrid.GetLength(0), cellGrid.GetLength(1)), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(cellGrid.GetLength(0), 0), GetWorldPosition(cellGrid.GetLength(0), cellGrid.GetLength(1)), Color.white, 100f);

        OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
        {
            debugTextArray[eventArgs.x, eventArgs.y].text = cellGrid[eventArgs.x, eventArgs.y]?.ToString();
        };
    }

    /// <summary>
    /// restituisce la posizione di una cella nel mondo dato l'indice di tale cella
    /// </summary>
    /// <param name="x">indice x</param>
    /// <param name="y">indice y</param>
    /// <returns> posizione della cella in Vector3 </returns>
    public Vector3 GetWorldPosition(int x, int y)
    {
        float trueX = (x * cellSize) + originPosition.x;
        float trueY = (y * cellSize) + originPosition.y;

        return new Vector3(trueX, trueY, originPosition.z);
    }

    /// <summary>
    /// restituisce l'indice della cella di appartenenza data una posizione nel mondo
    /// </summary>
    /// <param name="worldPosition"> la posizione cercata </param>
    /// <param name="x"> variabile di out contenente l'indice x </param>
    /// <param name="y"> variabile di out contenente l'indice y </param>
    public void GetGridPosition(Vector3 worldPosition, out int x, out int y)
    {
        y = Mathf.FloorToInt(((worldPosition.y - originPosition.y) / cellSize));
        x = Mathf.FloorToInt(((worldPosition.x - originPosition.x) / cellSize));
    }

    /// <summary>
    /// imposta il valore di una cella partendo da una posizione vettoriale
    /// </summary>
    /// <param name="worldPosition"> posizione nel mondo della cella </param>
    /// <param name="value"> valore da impostare </param>
    public void SetGridItem(Vector3 worldPosition, TGridObject value)
    {
        GetGridPosition(worldPosition, out int x, out int y);
        SetGridItem(x, y, value);
    }

    /// <summary>
    /// imposta il valore di una cella dati gli indici
    /// </summary>
    /// <param name="x"> indice x della cella </param>
    /// <param name="y"> indice y della cella </param>
    /// <param name="value"> valore da impostare </param>
    public void SetGridItem(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < cellGrid.GetLength(0) && y < cellGrid.GetLength(1))
        {
            cellGrid[x, y] = value;
            debugTextArray[x, y].text = value.ToString();
        }
    }

    /// <summary>
    /// restituisci il valore di una cella data una posizione vettoriale
    /// </summary>
    /// <param name="worldPosition"> posizione nel mondo della cella </param>
    /// <returns> valore contenuto </returns>
    public TGridObject GetGridItem(Vector3 worldPosition)
    {
        GetGridPosition(worldPosition, out int x, out int y);
        return GetGridItem(x, y);
    }

    /// <summary>
    /// restituisci il valore di una cella dati gli indici
    /// </summary>
    /// <param name="x"> indice x della cella </param>
    /// <param name="y"> indice y della cella </param>
    /// <returns> valore contenuto </returns>
    public TGridObject GetGridItem(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < cellGrid.GetLength(0) && y < cellGrid.GetLength(1))
            return cellGrid[x, y];
        else return default;
    }

    public void TriggetObjectChanged(int x, int y)
    {
        OnGridValueChanged?.Invoke(this, new OnGridValueChangedEventArgs { x = x, y = y });
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

}