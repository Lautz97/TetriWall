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
        if (GamePlaySettings.vibration)
        {
            Vibration.Vibrate(100);
        }
    }
    private void VibrateCollided()
    {
        if (GamePlaySettings.vibration)
        {
            Vibration.Vibrate(300);
        }
    }
    private void VibrateLevel()
    {
        if (GamePlaySettings.vibration)
        {
            Vibration.Vibrate(200);
        }
    }

    private void VibrateInput()
    {
        if (GamePlaySettings.vibrationMovement)
        {
            Vibration.Vibrate(15);
        }
    }

    private void VibrateButtons()
    {
        if (GamePlaySettings.vibrationButtons)
        {
            Vibration.Vibrate(50);
        }
    }


}
