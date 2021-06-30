using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputConstraintOverHUD : MonoBehaviour
{

    private void OnEnable()
    {
        StateManager.OnLoading += InterceptInput;
        StateManager.OnGameOver += InterceptInput;
        StateManager.OnMainMenu += InterceptInput;
        StateManager.OnPause += InterceptInput;

        StateManager.OnResume += AdmitInput;
        StateManager.OnInitialize += AdmitInput;

        TutorialHUD.OnTutorialStart += InterceptInput;
        TutorialHUD.OnTutorialEnd += AdmitInput;
    }
    private void OnDisable()
    {
        StateManager.OnLoading -= InterceptInput;
        StateManager.OnGameOver -= InterceptInput;
        StateManager.OnMainMenu -= InterceptInput;
        StateManager.OnPause -= InterceptInput;

        StateManager.OnResume -= AdmitInput;
        StateManager.OnInitialize -= AdmitInput;

        TutorialHUD.OnTutorialStart -= InterceptInput;
        TutorialHUD.OnTutorialEnd -= AdmitInput;
    }

    private void AdmitInput()
    {
        GamePlaySettings.CanMove = true;
    }

    private void InterceptInput()
    {
        GamePlaySettings.CanMove = false;
    }

}
