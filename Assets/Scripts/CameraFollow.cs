using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private float playerOffset = 4f;

    private Transform player;

    private Vector3 tempPos;
    
    

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null) player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }
    
    private void FollowPlayer()
    {
        tempPos = transform.position;

        if (player != null)
        {
            tempPos.y = player.position.y + playerOffset;
        }

        transform.position = tempPos;
    }
}
