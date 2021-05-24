using UnityEngine;

public class InitialPawnBooster : MonoBehaviour
{
    private float targetSpeed;
    private float boostSpeed;

    private float zStart;
    private float brakeTime;

    public GameObject tutorialPanel;

    private void Awake()
    {
        targetSpeed = GamePlaySettings.initialSpeed;
        boostSpeed = 65;
        brakeTime = 0.25f;
        zStart = transform.position.z;
    }

    bool openTutorial = true;
    float slowDownPosition = GamePlaySettings.showTutorial ? 200 : 250;

    private void FixedUpdate()
    {
        if (GamePlaySettings.showTutorial && openTutorial)
        {
            openTutorial = false;
            tutorialPanel.SetActive(true);
        }

        // if (!tutorialPanel.activeInHierarchy)
        // {
        //     slowDownPosition = 250;
        // }else{

        //     slowDownPosition = 200;
        // }

        if (transform.position.z - zStart < slowDownPosition)
            GamePlayCounters.actualSpeed = targetSpeed + boostSpeed;
        else
        {
            if (GamePlayCounters.actualSpeed >= targetSpeed + 2)
            {
                GamePlayCounters.actualSpeed -= Mathf.Lerp(targetSpeed + boostSpeed, targetSpeed, brakeTime);
            }
            else
            {
                if (tutorialPanel.activeInHierarchy && GamePlayCounters.actualSpeed != 0)
                {
                    PausePlay();
                }
                if (!tutorialPanel.activeInHierarchy)
                {
                    GamePlayCounters.actualSpeed = targetSpeed;
                    Destroy(this);
                }
            }
        }
    }

    private void PausePlay()
    {
        GamePlayCounters.actualSpeed = 0;
    }


}
