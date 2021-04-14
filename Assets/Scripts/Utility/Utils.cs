using UnityEngine;
public class Utils : MonoBehaviour
{
    public static Vector3 Screen2World(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToViewportPoint(position);
    }

    [SerializeField] public enum Direction { North, East, South, West }

    [SerializeField] public enum Shape { zero, Q, L, J, I, Z, S, T }

}