using System;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{

    public static Action PassedCorrectly;
    public static Action PassedWrongly;

    private bool checkT = true, checkC = true;


    // this should trigger the "Player Success" state
    //TODO better positioning of the attached block required
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Brick" && checkT)
        {
            checkT = false;
            AttachPawn(other.transform.parent.parent.transform);
            PassedCorrectly?.Invoke();
        }
    }

    // attach pawn to wall
    private void AttachPawn(Transform pawn)
    {
        // pawn.position = Vector3.Scale(pawn.position, Vector3.up + Vector3.right) + Vector3.Scale(Vector3.forward, transform.position);
        pawn.SetParent(transform);
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
