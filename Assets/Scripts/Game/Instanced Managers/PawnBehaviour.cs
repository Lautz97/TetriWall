﻿using UnityEngine;

public class PawnBehaviour : MonoBehaviour
{
    [SerializeField] private Material BGMaterial;
    [SerializeField] private float parallaxFactor = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        BGMaterial.mainTextureOffset = Vector2.zero;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float speed = GamePlayCounters.actualSpeed * GamePlayCounters.actualSpeedMultiplier;
        BGMaterial.mainTextureOffset += (Vector2.up * speed * Time.deltaTime) / parallaxFactor;
        transform.position += (Vector3.forward * Time.deltaTime * speed);
    }
    private void OnEnable()
    {
        StateManager.OnPlay += AddBooster;
    }

    private void OnDisable()
    {
        StateManager.OnPlay -= AddBooster;
    }

    void AddBooster()
    {
        if (!StateManager.isInitialized)
            gameObject.AddComponent<InitialPawnBooster>();
    }
}
