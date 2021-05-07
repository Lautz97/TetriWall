using System;
using UnityEngine;

public class ChunkBehaviour : MonoBehaviour
{
    public static Action EndTileTriggered;
    public Vector3 NextSpawnPoint => transform.GetChild(2).transform.position;
    private bool alive = true;
    [SerializeField] private float remainingTime;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && alive)
        {
            alive = false;
            OnPlayerPass();
        }
    }
    void OnPlayerPass()
    {
        EndTileTriggered?.Invoke();
        Destroy(gameObject, remainingTime);
    }
}
