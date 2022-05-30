using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float scrollSpeed = 3f;

    private float rightEdge = 8.4f;
    private float leftEdge = -8.4f;
    private float movementX;
    
    public float playerHP;

    EnemyAI enemyAI;
    [SerializeField] GameObject enemy;
  
    private Rigidbody2D playerBody;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        enemyAI = enemy.GetComponent<EnemyAI>();
    }

    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void GetPlayerInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        playerBody.velocity = new Vector2(movementX * moveSpeed, scrollSpeed);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log(playerHP);
        Debug.Log(enemyAI.enemyHP);

        if(collision.gameObject.tag.Equals("Enemy")) 
        {
            
            if(playerHP > enemyAI.enemyHP)
            {
                Destroy(enemyAI.gameObject);
            }
                
            if(playerHP == enemyAI.enemyHP)
            {
                Destroy(enemyAI.gameObject);
                Destroy(this.gameObject);
            }
            if(playerHP < enemyAI.enemyHP)
                Destroy(this.gameObject);

        }
        playerHP -= enemyAI.enemyHP;
        enemyAI.enemyHP -= enemyAI.enemyHP;
        if(playerHP < 0) playerHP = 0;
        Debug.Log(playerHP);
        Debug.Log(enemyAI.enemyHP);
    }

}//class