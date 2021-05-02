using System.Collections;
using UnityEngine;

public class SwipeInteraction : MonoBehaviour
{
    // fix bugs (?)
    // ad a preference tool
    [SerializeField] private float minDist = .2f, maxtime = 1f;

    [SerializeField, Range(0f, 1f)] private float dirThreshold = .9f;

    private Vector2 startPosition, endPosition;
    private float startTime, endTime;

    public static System.Action<Vector2> SwipeDetected;
    public static System.Action TapDetected;

    public void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    public void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;

        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if ((endTime - startTime) <= maxtime)
        {
            if (Vector3.Distance(startPosition, endPosition) >= minDist)
            {
                Vector3 dir = endPosition - startPosition;
                SwipeDirection(dir);
            }
            else
            {
                SwipeDirection(Vector2.zero);
            }
        }
        else
        {
            SwipeDirection(Vector2.zero);
        }
    }

    private void SwipeDirection(Vector2 dir)
    {
        if (dir == Vector2.zero)
        {
            TapDetected?.Invoke();
        }
        else
        {
            if (Vector2.Dot(Vector2.left, dir) > dirThreshold)
            {
                SwipeDetected?.Invoke(Vector2.left);
            }
            else if (Vector2.Dot(Vector2.right, dir) > dirThreshold)
            {
                SwipeDetected?.Invoke(Vector2.right);
            }
            else if (Vector2.Dot(Vector2.up, dir) > dirThreshold)
            {
                // SwipeDetected?.Invoke(Vector2.up);
            }
            else if (Vector2.Dot(Vector2.down, dir) > dirThreshold)
            {
                // SwipeDetected?.Invoke(Vector2.down);
            }
        }
    }

}
