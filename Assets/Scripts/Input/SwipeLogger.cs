using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        SwipeDetector.OnSwipe += Swipe_Log;
    }

    // Update is called once per frame
    void Swipe_Log(SwipeData sw)
    {
        print("swipeDir: " + sw.Direction);
    }
}
