using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;


    private float movementX;
    [SerializeField] private float scrollSpeed = 3f;

    private Rigidbody2D playerBody;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FlipPlayer();
    }
    
    private void GetPlayerInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        playerBody.velocity = new Vector2(movementX * moveSpeed, scrollSpeed);
    }
    
    private void FlipPlayer()
    {
        if (movementX > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movementX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
