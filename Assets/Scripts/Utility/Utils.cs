using UnityEngine;
public class Utils : MonoBehaviour
{
    public static Vector3 Screen2World(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToViewportPoint(position);
    }
}
