using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBehaviour : MonoBehaviour
{

    public Vector3 NextSpawnPoint => transform.GetChild(2).transform.position;

    [SerializeField] private float remainingTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.EndTileTriggered();
            OnPlayerPass();
        }
    }
    void OnPlayerPass()
    {
        Destroy(gameObject, remainingTime);
    }
}
