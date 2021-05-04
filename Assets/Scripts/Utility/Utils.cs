using UnityEngine;
public class Utils : MonoBehaviour
{
    public static Vector3 Screen2World(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToViewportPoint(position);
    }

    public static string currentScoreKey = "currentScore", hiScoreKey = "highestScore";

    public static float minSwipeDistance = 20f;

    public static float maxTimeSwipe = 2f;

    public static bool detectOnlyAfterRelease = true;

    public static bool onlyHorizontal = true;

}