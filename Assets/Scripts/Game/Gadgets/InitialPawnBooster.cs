using UnityEngine;

public class InitialPawnBooster : MonoBehaviour
{

    private float targetSpeed;
    private float boostSpeed;

    private float zStart;
    private float brakeTime;

    private void Awake()
    {
        targetSpeed = 15;
        boostSpeed = 65;
        brakeTime = 0.25f;
        zStart = transform.position.z;
    }
    private void FixedUpdate()
    {
        if (transform.position.z - zStart < 250)
            PawnBehaviour.Instance.speed = targetSpeed + boostSpeed;
        else
        {
            if (PawnBehaviour.Instance.speed >= targetSpeed + 2)
            {
                PawnBehaviour.Instance.speed -= Mathf.Lerp(targetSpeed + boostSpeed, targetSpeed, brakeTime);
            }
            else
            {
                PawnBehaviour.Instance.speed = targetSpeed;
                Destroy(this);
            }
        }
    }


}
