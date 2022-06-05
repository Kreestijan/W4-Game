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

    PowerUps shieldRef;
    [SerializeField] GameObject shield;

    private Rigidbody2D playerBody;

    [HideInInspector] public bool isPlayerDead = false;

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
        playerBody.velocity = new Vector2(movementX * moveSpeed, scrollSpeed);
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

    void Operatii()//Citire tag-uri
    {
        
        char[] spearator = { ' ' };

        // using the method
        String[] strlist = gateOperation.Split(spearator);

        foreach (String s in strlist)
        {
            Debug.Log("The elements are : \n" + s);
        }
        Debug.Log(strlist[1]);//al doilea element pentru instantiere


        if (strlist[0] == "+")//Instantiere playerobject
        {
            for (var i = 0; i <= Int16.Parse(strlist[1]); i++)
                Instantiate(playerBody);

        }
        //continuare pentru scadere, impartire samd...


    }

    private void OnTriggerEnter2D(Collider2D collision)//Trigger pentru Gate-uri

    {
        gateOperation = collision.gameObject.tag;
        Debug.Log(collision.gameObject.tag);
        Destroy(collision.gameObject);
        gateOperation = collision.gameObject.tag;
        Debug.Log(gateOperation.GetType());
        Operatii();
    }
    
    private void GetDistanceTraveled()
    {
        distanceTraveled = transform.position.y - startingPositionY;
    }
    

}//class
