using System;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{

    public static Action PassedCorrectly;
    public static Action PassedWrongly;

    bool checkT = true, checkC = true;


    // this should trigger the "Player Success" state
    //TODO better positioning of the attached block required
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Brick" && checkT)
        {
            checkT = false;
            Transform t = other.transform.parent.parent.transform;
            // t.position = Vector3.Scale(t.position, Vector3.up + Vector3.right) + Vector3.Scale(Vector3.forward, transform.position);
            t.SetParent(transform);
            PassedCorrectly?.Invoke();
        }
    }

    // this should trigger the "Player Error" state
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Pawn" && checkC)
        {
            checkC = false;
            PassedWrongly?.Invoke();
        }
    }
}
