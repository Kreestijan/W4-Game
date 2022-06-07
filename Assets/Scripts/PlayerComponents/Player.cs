using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private float moveSpeed = 20f;

    [SerializeField] private float scrollSpeed = 3f;

    [HideInInspector] public float distanceTraveled;

    private float startingPositionY;
    
    private string gateOperation;

    private float movementX;
    
    public float playerHP;

    EnemyAI enemyAI;
    [SerializeField] GameObject enemy;

    PowerUps shieldRef;
    [SerializeField] GameObject shield;

    private Rigidbody2D playerBody;

    [HideInInspector] public bool isPlayerDead = false;

    private Vector3 mousePosition;
    private Vector3 aimDirection;
    [SerializeField] bool isShielded = false;

    //insert more powerups attributes here (bool preferably)

    private void Awake()
    {
        instance = this;
        
        distanceTraveled = 0f;

        playerBody = GetComponent<Rigidbody2D>();
        enemyAI = enemy.GetComponent<EnemyAI>();
        shieldRef = shield.GetComponent<PowerUps>();
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
        mousePosition = UtilsClass.GetMouseWorldPosition();

        aimDirection = (mousePosition - transform.position).normalized;



        playerBody.velocity = new Vector2(movementX * moveSpeed, scrollSpeed);
        //playerBody.velocity = new Vector2(aimDirection.x * moveSpeed, scrollSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyAI != null)
        {
            if (collision.gameObject.CompareTag("Shield"))
            {
                isShielded = true;
                shieldRef.isSpawned = false;

                Destroy(shieldRef.gameObject);
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                
                if (isShielded == true)
                {
                    enemyAI.canCollide=false;
                    
                    isShielded = !isShielded;
                }


                else
                {
                    if (playerHP > enemyAI.enemyHP)
                    {
                        enemyAI.canCollide=false;
                        playerHP -= enemyAI.enemyHP;
                        enemyAI.enemyHP -= enemyAI.enemyHP;
                    }
                    if (playerHP <= enemyAI.enemyHP)
                    {
                        Destroy(this.gameObject);
                        
                        playerHP -= enemyAI.enemyHP;
                        enemyAI.enemyHP -= enemyAI.enemyHP;
                        playerHP = 0;
                    }

                }

                if(enemyAI.canCollide == false)
                    Destroy(enemyAI.gameObject);

            }
            Debug.Log(playerHP);
            Debug.Log(enemyAI.enemyHP);
            Debug.Log(isShielded);
        }
    }

    

    

    private void GetDistanceTraveled()
    {
        distanceTraveled = transform.position.y - startingPositionY;
    }
    

}//class
