using UnityEngine;

public class InitialPawnBooster : MonoBehaviour
{

    private float targetSpeed;
    private float startingSpeed;

    private float zStart;
    private void Awake()
    {
        targetSpeed = 15;
        startingSpeed = 65;
        zStart = transform.position.z;
    }
    private void FixedUpdate()
    {
        if (transform.position.z - zStart < 250)
            PawnBehaviour.Instance.speed = targetSpeed + startingSpeed;
        else
        {
            PawnBehaviour.Instance.speed = targetSpeed;
            Destroy(this);
        }
    }


}
