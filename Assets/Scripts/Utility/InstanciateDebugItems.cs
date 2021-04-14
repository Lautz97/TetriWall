using UnityEngine;

public static class InstanciateDebugItems
{
    /// <summary>
    /// genera un oggetto testuale di debug
    /// </summary>
    /// <param name="text">testo contenuto</param>
    /// <param name="parent">transform padre</param>
    /// <param name="localPosition">posizione locale rispetto al padre</param>
    /// <param name="fontSize">grandezza del font</param>
    /// <param name="color">colore del font</param>
    /// <param name="textAnchor">ancoraggio del testo</param>
    /// <param name="textAlignment">allineamento del testo</param>
    /// <param name="sortingOrder"></param>
    /// <returns></returns>
    public static GameObject CreateText(string text, Transform parent = null, Vector3 localPosition = default, int fontSize = 40, Color color = default, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
    {
        GameObject gameObject = new GameObject("Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.position = localPosition;

        transform.SetParent(parent);

        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.characterSize = (float)fontSize / 100;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return gameObject;
    }

    /// <summary>
    /// genera un oggetto testuale di debug
    /// </summary>
    /// <param name="spawnable">oggetto da instanziare</param>
    /// <param name="parent">transform padre</param>
    /// <param name="localPosition">posizione locale rispetto al padre</param>
    /// <returns></returns>
    public static GameObject CreateItem(GameObject spawnable, Transform parent = null, Vector3 localPosition = default)
    {
        GameObject retObj = MonoBehaviour.Instantiate(spawnable, parent);
        retObj.transform.position = localPosition;

        return retObj;
    }
}