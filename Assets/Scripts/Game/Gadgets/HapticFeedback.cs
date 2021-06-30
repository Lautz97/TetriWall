using System;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{
    public static Action OnWallPassed, OnWallCollided, OnSwipe, OnTap, OnButtonPressed, OnLevelChange;

    private void OnEnable()
    {
        OnTap += VibrateInput;
        OnSwipe += VibrateInput;

        OnWallPassed += VibratePassed;
        OnWallCollided += VibrateCollided;

        OnButtonPressed += VibrateButtons;

        OnLevelChange += VibrateLevel;
    }
    private void OnDisable()
    {
        OnTap -= VibrateInput;
        OnSwipe -= VibrateInput;

        OnWallPassed -= VibratePassed;
        OnWallCollided -= VibrateCollided;

        OnButtonPressed -= VibrateButtons;

        OnLevelChange -= VibrateLevel;
    }

    private void VibratePassed()
    {
        Vibration.Vibrate(100);
    }
    private void VibrateCollided()
    {
        Vibration.Vibrate(300);
    }

    private void VibrateInput()
    {
        Vibration.Vibrate(15);
    }

    private void VibrateButtons()
    {
        Vibration.Vibrate(50);
    }

    private void VibrateLevel()
    {
        Vibration.Vibrate(200);
    }

}
