using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    [SerializeField] private float parallaxSpeed = 1f;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private Sprite sprite;
    private Texture2D texture;
    private float textureUnitSizeY;
    private float offsetPositionY;



    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        sprite = GetComponent<SpriteRenderer>().sprite;
        texture = sprite.texture;
        textureUnitSizeY = (texture.height / sprite.pixelsPerUnit) * transform.localScale.y;
    }
    
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxSpeed;
        lastCameraPosition = cameraTransform.position;

        if (cameraTransform.position.y - transform.position.y >= textureUnitSizeY)
        {
            offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
        }
    }
}//class
