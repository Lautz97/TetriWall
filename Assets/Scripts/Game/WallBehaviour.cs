using System;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{

    public static Action PassedCorrectly;
    public static Action PassedWrongly;

    bool checkT = true, checkC = true;

    //TODO better positioning required
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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Pawn" && checkC)
        {
            checkC = false;
            PassedWrongly?.Invoke();
        }
    }
}
