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
            Debug.Log("Trigger" + other.name);
            GameManager.Instance.PassedWallTriggered(transform);
        }
        // else
        //     Debug.Log("Trigger" + other.name);
    }
    /// TODO PLAYER TRIGGER IS A PROBLEM
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Pawn" && checkC)
        {
            checkC = false;
            Debug.Log("Collider" + other.gameObject.name);
            GameManager.Instance.HitWallTriggered();
        }
        // else
        //     Debug.Log("Collider" + other.gameObject.name);
    }
}
