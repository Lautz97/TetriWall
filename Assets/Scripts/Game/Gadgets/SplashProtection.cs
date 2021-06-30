using UnityEngine;
using UnityEngine.Rendering;

public class SplashProtection : MonoBehaviour
{
    void Update()
    {
        // Debug.Log(SplashScreen.isFinished);
        if (SplashScreen.isFinished)
        {
            gameObject.SetActive(false);
        }
    }
}
