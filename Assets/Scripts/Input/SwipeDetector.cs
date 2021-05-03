using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private bool testInput = false;
    private bool onlyHorizontal = true;
    private Vector2 downPosition, upPosition;
    private float downTime, upTime;
    private bool detectOnlyAfterRelease = true;
    [SerializeField] private float minSwipeDistance = 20f;
    [SerializeField] private float maxTimeSwipe = 2f;
    public static Action<SwipeData> OnSwipe;

    private void Awake()
    {
#if UNITY_EDITOR
        testInput = true;
#endif
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                SetPositionAndTime(t.position, out downPosition, out downTime);
                SetPositionAndTime(t.position, out upPosition, out upTime);
            }
            if (!detectOnlyAfterRelease && t.phase == TouchPhase.Moved)
            {
                SetPositionAndTime(t.position, out downPosition, out downTime);
                DetectSwipe();
            }
            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                SetPositionAndTime(t.position, out downPosition, out downTime);
                DetectSwipe();
            }
        }
        if (testInput)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                SetPositionAndTime(Vector2.left * minSwipeDistance, out downPosition, out downTime);
                SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                DetectSwipe();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                SetPositionAndTime(Vector2.right * minSwipeDistance, out downPosition, out downTime);
                SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                DetectSwipe();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                SetPositionAndTime(Vector2.up * minSwipeDistance, out downPosition, out downTime);
                SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                DetectSwipe();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                SetPositionAndTime(Vector2.down * minSwipeDistance, out downPosition, out downTime);
                SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                DetectSwipe();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetPositionAndTime(Vector2.zero, out downPosition, out downTime);
                SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (!maxTimeExceeded())
        {
            if (minSwipeDistanceCheck())
            {
                if (Math.Abs(HorizontalMovement()) >= Math.Abs(VerticalMovement()))
                {
                    SendSwipe(Vector2.right * Math.Sign(HorizontalMovement()));
                }
                if (Math.Abs(HorizontalMovement()) < Math.Abs(VerticalMovement()) && !onlyHorizontal)
                {
                    SendSwipe(Vector2.up * Math.Sign(VerticalMovement()));
                }
            }
            if (!minSwipeDistanceCheck())
            {
                SendSwipe(Vector2.zero);
            }
        }
        SetPositionAndTime(downPosition, out upPosition, out upTime);
    }

    private void SendSwipe(Vector2 dir)
    {
        SwipeData swipe = new SwipeData()
        {
            Direction = dir,
            StartPosition = downPosition,
            EndPosition = upPosition
        };
        OnSwipe?.Invoke(swipe);
    }

    private bool maxTimeExceeded() => (downTime - upTime) > maxTimeSwipe;
    private bool minSwipeDistanceCheck() => (Math.Abs(VerticalMovement()) >= minSwipeDistance || Math.Abs(HorizontalMovement()) >= minSwipeDistance);
    private float VerticalMovement() => (downPosition.y - upPosition.y);
    private float HorizontalMovement() => (downPosition.x - upPosition.x);

    private void SetPositionAndTime(Vector2 position, out Vector2 positionVector, out float timeFloat)
    {
        positionVector = position;
        timeFloat = Time.time;
    }

}
public struct SwipeData
{
    public Vector2 StartPosition, EndPosition;
    public Vector2 Direction;
}