using UnityEngine;

public class CustomInputManager : Singleton<CustomInputManager>
{

    private bool testInput = false;
    [SerializeField] private SwipeInteraction swipe;

    private Vector3 lastSensedPosition;

    private void Awake()
    {
#if UNITY_EDITOR
        testInput = true;
#endif
    }

    private void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    lastSensedPosition = touch.position;
                    swipe.SwipeStart(lastSensedPosition, Time.time);
                    break;

                case TouchPhase.Moved:
                    lastSensedPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    lastSensedPosition = touch.position;
                    swipe.SwipeEnd(lastSensedPosition, Time.time);
                    break;

                case TouchPhase.Canceled:
                    swipe.SwipeEnd(lastSensedPosition, Time.time);
                    break;
            }
        }
        if (testInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastSensedPosition = Input.mousePosition;
                swipe.SwipeStart(lastSensedPosition, Time.time);
            }
            if (Input.GetMouseButtonUp(0))
            {
                lastSensedPosition = Input.mousePosition;
                swipe.SwipeEnd(lastSensedPosition, Time.time);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                swipe.SwipeStart(Vector3.zero, Time.time);
                swipe.SwipeEnd(Vector3.zero, Time.time);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                swipe.SwipeStart(Vector3.zero, Time.time);
                swipe.SwipeEnd(Vector3.up, Time.time);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                swipe.SwipeStart(Vector3.zero, Time.time);
                swipe.SwipeEnd(Vector3.down, Time.time);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                swipe.SwipeStart(Vector3.zero, Time.time);
                swipe.SwipeEnd(Vector3.right, Time.time);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                swipe.SwipeStart(Vector3.zero, Time.time);
                swipe.SwipeEnd(Vector3.left, Time.time);
            }
        }
    }
}