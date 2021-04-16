using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    bool checkT = true, checkC = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Brick" && checkT)
        {
            checkT = false;
            GameManager.Instance.PassedWallTriggered(transform);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Pawn" && checkC)
        {
            checkC = false;
            GameManager.Instance.HitWallTriggered();
        }
    }
}
