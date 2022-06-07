using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxWithoutLooping : MonoBehaviour
{

    [SerializeField] private float parallaxSpeed = 1f;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Awake()
    {
        GetComponentsForParallax();
    }

    void LateUpdate()
    {
        UseParallaxEffect();
    }

    private void GetComponentsForParallax()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void UseParallaxEffect()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxSpeed;
        lastCameraPosition = cameraTransform.position;
    }

}//class
