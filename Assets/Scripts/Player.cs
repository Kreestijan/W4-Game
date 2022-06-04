using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float scrollSpeed = 3f;

    [HideInInspector] public float distanceTraveled;

    private float startingPositionY;
    
    private string gateOperation;

    private float movementX;
    
    public float playerHP;

    EnemyAI enemyAI;
    [SerializeField] GameObject enemy;

    private Rigidbody2D playerBody;

    [HideInInspector] public bool isPlayerDead = false;

    private void Awake()
    {
        instance = this;
        
        distanceTraveled = 0f;

        playerBody = GetComponent<Rigidbody2D>();
        enemyAI = enemy.GetComponent<EnemyAI>();
    }

    private void Start()
    {
        startingPositionY = transform.position.y;
    }
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        GetDistanceTraveled();
    }
    
    private void GetPlayerInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        playerBody.velocity = new Vector2(movementX * moveSpeed, scrollSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
       Debug.Log(playerHP);
       Debug.Log(enemyAI.enemyHP);

        if (collision.gameObject.tag.Equals("Enemy"))
        {

            if (playerHP > enemyAI.enemyHP)
            {
                Destroy(enemyAI.gameObject);
            }

            if (playerHP == enemyAI.enemyHP)
            {
                Destroy(enemyAI.gameObject);
                Destroy(this.gameObject);
            }
            if (playerHP < enemyAI.enemyHP)
                Destroy(this.gameObject);

        }
        playerHP -= enemyAI.enemyHP;
        enemyAI.enemyHP -= enemyAI.enemyHP;
        if (playerHP < 0) playerHP = 0;
        // Debug.Log(playerHP);
        // Debug.Log(enemyAI.enemyHP);
    }

    

    

    private void GetDistanceTraveled()
    {
        distanceTraveled = transform.position.y - startingPositionY;
    }
    

}//class
