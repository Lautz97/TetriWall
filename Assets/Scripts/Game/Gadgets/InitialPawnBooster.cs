using UnityEngine;

public class InitialPawnBooster : MonoBehaviour
{

    private float targetSpeed;
    private float boostSpeed;

    private float zStart;
    private float brakeTime;

    private void Awake()
    {
        targetSpeed = GamePlaySettings.initialSpeed;
        boostSpeed = 65;
        brakeTime = 0.25f;
        zStart = transform.position.z;
    }
    private void FixedUpdate()
    {
        if (transform.position.z - zStart < 250)
            GamePlayCounters.actualSpeed = targetSpeed + boostSpeed;
        else
        {
            if (GamePlayCounters.actualSpeed >= targetSpeed + 2)
            {
                GamePlayCounters.actualSpeed -= Mathf.Lerp(targetSpeed + boostSpeed, targetSpeed, brakeTime);
            }
            else
            {
                GamePlayCounters.actualSpeed = targetSpeed;
                Destroy(this);
            }
        }
    }


}
