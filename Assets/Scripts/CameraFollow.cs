using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //How much should the player be offset from the camera's origin point on the y axis
    [SerializeField] private float playerOffset = 4f;

    private Transform playerTransform;

    private Vector3 tempPos;
    
    

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null) playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }
    
    private void FollowPlayer()
    {
        tempPos = transform.position;

        if (playerTransform != null)
        {
            tempPos.y = playerTransform.position.y + playerOffset;
        }

        transform.position = tempPos;
    }
}
