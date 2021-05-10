using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private bool testInput = false;
    private Vector2 downPosition, upPosition;
    private float downTime, upTime;
    public static Action<SwipeData> OnSwipe;

    private void Awake()
    {
#if UNITY_EDITOR
        testInput = true;
#endif
    }


    private void Update()
    {
        TouchPhase lastPhase = TouchPhase.Began;
        if (StateManager.GetGameState == GameState.playing)
        {
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    SetPositionAndTime(t.position, out downPosition, out downTime);
                    SetPositionAndTime(t.position, out upPosition, out upTime);
                }
                if (!InputSettings.detectOnlyAfterRelease && (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary))
                {
                    SetPositionAndTime(t.position, out downPosition, out downTime);
                    if (minSwipeDistanceCheck())
                    {
                        DetectSwipe();
                    }
                }
                if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
                {
                    SetPositionAndTime(t.position, out downPosition, out downTime);
                    if (!minSwipeDistanceCheck() && lastPhase == TouchPhase.Began)
                    {
                        DetectSwipe();
                    }
                }
                lastPhase = t.phase;
            }
            if (testInput)
            {
                float credibilityMultiplier = 999;// InputSettings.minSwipeDistance + InputSettings.maxTapDistance;

                // if (Input.GetKeyDown(KeyCode.Escape)) StateManager.UpdateState(StateManager.GetGameState == GameState.paused ? GameState.playing : GameState.paused);
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    SetPositionAndTime(Vector2.left * credibilityMultiplier, out downPosition, out downTime);
                    SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                    DetectSwipe();
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    SetPositionAndTime(Vector2.right * credibilityMultiplier, out downPosition, out downTime);
                    SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                    DetectSwipe();
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    SetPositionAndTime(Vector2.up * credibilityMultiplier, out downPosition, out downTime);
                    SetPositionAndTime(Vector2.zero, out upPosition, out upTime);
                    DetectSwipe();
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    SetPositionAndTime(Vector2.down * credibilityMultiplier, out downPosition, out downTime);
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
    }

    private void DetectSwipe()
    {
        if (!maxSwipeTimeExceeded())
        {
            if (minSwipeDistanceCheck() && !maxTapDistanceCheck())
            {
                if (Math.Abs(HorizontalMovement()) >= Math.Abs(VerticalMovement()))
                {
                    SendSwipe(Vector2.right * Math.Sign(HorizontalMovement()));
                }
                if (Math.Abs(HorizontalMovement()) < Math.Abs(VerticalMovement()) && !GamePlaySettings.onlyHorizontal)
                {
                    SendSwipe(Vector2.up * Math.Sign(VerticalMovement()));
                }
            }
            if (!minSwipeDistanceCheck() && maxTapDistanceCheck())
            {
                if (!maxTapTimeExceeded()) SendSwipe(Vector2.zero);
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

    private bool maxSwipeTimeExceeded() => (downTime - upTime) > InputSettings.maxSwipeTime;
    private bool maxTapTimeExceeded() => (downTime - upTime) > InputSettings.maxTapTime;
    private bool maxTapDistanceCheck() => (Math.Abs(VerticalMovement()) < InputSettings.maxTapDistance && Math.Abs(HorizontalMovement()) < InputSettings.maxTapDistance);
    private bool minSwipeDistanceCheck() => (Math.Abs(VerticalMovement()) >= InputSettings.minSwipeDistance || Math.Abs(HorizontalMovement()) >= InputSettings.minSwipeDistance);
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