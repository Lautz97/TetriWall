﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputConstraintOverHUD : MonoBehaviour
{
    public static Action OnFilterNeeded, OnFilterRemoved;
    private void OnEnable()
    {
        OnFilterNeeded += InterceptInput;
        OnFilterRemoved += AdmitInput;

        TutorialHUD.OnTutorialStart += InterceptInput;
        TutorialHUD.OnTutorialEnd += AdmitInput;
    }
    private void OnDisable()
    {
        OnFilterNeeded -= InterceptInput;
        OnFilterRemoved -= AdmitInput;

        TutorialHUD.OnTutorialStart -= InterceptInput;
        TutorialHUD.OnTutorialEnd -= AdmitInput;
    }

    private void AdmitInput()
    {
        Debug.Log("si");
        GamePlaySettings.CanMove = true;
    }

    private void InterceptInput()
    {
        Debug.Log("no");
        GamePlaySettings.CanMove = false;
    }

}
