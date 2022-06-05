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
