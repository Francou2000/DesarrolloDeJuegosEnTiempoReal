using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float width;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        Vector3 deltamovement = cameraTransform.position - lastCameraPosition;

        transform.position += new Vector3(deltamovement.x * parallaxEffectMultiplier, 0.0f, 0.0f);

        lastCameraPosition = cameraTransform.position;

        float distanceWithTheCamera = cameraTransform.position.x - transform.position.x;

        if(Math.Abs(distanceWithTheCamera) >= width)
        {
            //var movement = distanceWithTheCamera > 0 ? width * 2f : width * -2f;
            //transform.position = new Vector3(transform.position.x + movement, transform.position.y, 0.0f);
        }
    }
}
