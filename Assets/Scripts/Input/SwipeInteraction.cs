using System.Collections;
using UnityEngine;

public class SwipeInteraction : MonoBehaviour
{
    // public GridManager gridManager;

    [SerializeField] private float minDist = .2f, maxtime = 1f;

    [SerializeField, Range(0f, 1f)] private float dirThreshold = .9f;

    private Vector2 startPosition, endPosition;
    private float startTime, endTime;

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
                // Vector2 dir2D = new Vector2(dir.x, dir.y).normalized;
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
            GameManager.Instance.RotatePawn();
            // gridManager.RotateActive();
        }
        else
        {
            if (Vector2.Dot(Vector2.left, dir) > dirThreshold)
            {
                GameManager.Instance.MovePawn(Vector2.left);
                // gridManager.MoveActive(Vector2.left);
            }
            else if (Vector2.Dot(Vector2.right, dir) > dirThreshold)
            {
                GameManager.Instance.MovePawn(Vector2.right);
                // gridManager.MoveActive(Vector2.right);
            }
            else if (Vector2.Dot(Vector2.up, dir) > dirThreshold)
            {
                GameManager.Instance.MovePawn(Vector2.up);
                // gridManager.MoveActive(Vector2.up);
            }
            else if (Vector2.Dot(Vector2.down, dir) > dirThreshold)
            {
                GameManager.Instance.MovePawn(Vector2.down);
                // gridManager.MoveActive(Vector2.down);
            }
        }
    }

}
