﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBehaviour : MonoBehaviour
{
    [SerializeField] private Material BGMaterial;
    [SerializeField] private float parallaxFactor = 1;
    [SerializeField] private float speed = 1;
    [SerializeField] private float speedMultiplier = 1;

    // Start is called before the first frame update
    void Awake()
    {
        BGMaterial.mainTextureOffset = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BGMaterial.mainTextureOffset += (Vector2.up * speed * speedMultiplier * Time.deltaTime) / parallaxFactor;
        transform.position += (Vector3.forward * Time.deltaTime * speed * speedMultiplier);
    }

    public void SetActiveShape(GameObject shape)
    {

    }
}