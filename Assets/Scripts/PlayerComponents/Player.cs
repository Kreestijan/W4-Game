using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float moveSpeed = 20f;

    [SerializeField] private float scrollSpeed = 3f;

    [HideInInspector] public float distanceTraveled;

    private float startingPositionY;
    
    private string gateOperation;

    public float movementX;
    
    public float playerHP;

    EnemyAI enemyAI;
    [SerializeField] GameObject enemy;

    PowerUps shieldScript;
    [SerializeField] GameObject shield;


    PowerUps killScript;
    [SerializeField] GameObject kill;



    private Rigidbody2D playerBody;

    [HideInInspector] public bool isPlayerDead = false;

    private Vector3 mousePosition;
    private Vector3 aimDirection;
    [SerializeField] bool isShielded = false;

    public Transform shieldAnimation;

    EnemySpawner enemySpawnerScript;
    [SerializeField] GameObject enemySpawner;

    PowerupSpawner powerupSpawnerScript;

    [SerializeField] GameObject powerupSpawner;

    //insert more powerups attributes here (bool preferably)

    private void Awake()
    {
        instance = this;
        
        distanceTraveled = 0f;

        playerBody = GetComponent<Rigidbody2D>();
        enemyAI = enemy.GetComponent<EnemyAI>();
        shieldScript = shield.GetComponent<PowerUps>();
        enemySpawnerScript = enemySpawner.GetComponent<EnemySpawner>();
        powerupSpawnerScript = powerupSpawner.GetComponent<PowerupSpawner>();
        killScript = kill.GetComponent<PowerUps>();
    }

    private void Start()
    {
        startingPositionY = transform.position.y;
        //shieldAnimation.GetComponent<ParticleSystem>().enableEmission = false;
    }
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        GetDistanceTraveled();
        ReassignInstances();
    }
    
    private void GetPlayerInput()
    {
        movementX = Input.GetAxisRaw("Horizontal");
    }

    void ReassignInstances()//function for reassigning the instances of new clones
    {
        if(enemy == null)
        {
            
            if(enemySpawnerScript.enemyOnScreen != null)
            {  
                enemy = enemySpawnerScript.enemyOnScreen;
            }
            
        }

        if(shield == null)
        {
            
            if(powerupSpawnerScript.shieldOnScreen != null)
            {  
                shield = powerupSpawnerScript.shieldOnScreen;
            }
            
        }

        if(kill == null)
        {
            if(powerupSpawnerScript.killPowerOnScreen != null)
            {  
                kill = powerupSpawnerScript.killPowerOnScreen;
            }
        }
    }

    private void MovePlayer()
    {
        mousePosition = UtilsClass.GetMouseWorldPosition();

        aimDirection = (mousePosition - transform.position).normalized;



        playerBody.velocity = new Vector2(movementX * moveSpeed, scrollSpeed);
    }

    private void GetDistanceTraveled()
    {
        distanceTraveled = transform.position.y - startingPositionY;
    }
    

}
