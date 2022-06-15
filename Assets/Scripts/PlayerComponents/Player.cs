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

    PowerUps shieldScript;
    [SerializeField] GameObject shield;

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
    }

    private void Start()
    {
        startingPositionY = transform.position.y;
        shieldAnimation.GetComponent<ParticleSystem>().enableEmission = false;
    }
    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        GetDistanceTraveled();
        //assign new clone objects references to player object
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
    }

    private void MovePlayer()
    {
        mousePosition = UtilsClass.GetMouseWorldPosition();

        aimDirection = (mousePosition - transform.position).normalized;



        playerBody.velocity = new Vector2(movementX * moveSpeed, scrollSpeed);
        //playerBody.velocity = new Vector2(aimDirection.x * moveSpeed, scrollSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (enemyAI != null)
        {
            
            if (collider.gameObject.CompareTag("Shield"))
            {
                isShielded = true;
                shieldScript.isSpawned = false;

                Destroy(shieldScript.gameObject);
                shieldAnimation.GetComponent<ParticleSystem>().enableEmission = true;
            }
            
    
            if (collider.gameObject.CompareTag("Enemy"))
            {
                
                if (isShielded == true)
                {
                    enemyAI.canCollide=false;
                    Destroy(enemyAI.gameObject);
                    isShielded = !isShielded;
                    StartCoroutine (stopAnimation());
                }


                else
                {
                    if (playerHP > enemyAI.enemyHP)
                    {
                        enemyAI.canCollide=false;
                        playerHP -= enemyAI.enemyHP;
                        enemyAI.enemyHP -= enemyAI.enemyHP;
                        Destroy(enemyAI.gameObject);
                    }
                    if (playerHP <= enemyAI.enemyHP)
                    {
                        Destroy(this.gameObject);
                        
                        playerHP -= enemyAI.enemyHP;
                        enemyAI.enemyHP -= enemyAI.enemyHP;
                        playerHP = 0;
                    }

                }

            }
            Debug.Log(playerHP);
            Debug.Log(enemyAI.enemyHP);
            Debug.Log(isShielded);
        }
    }

    IEnumerator stopAnimation()
    {
        yield return new WaitForSeconds(.1f);
        shieldAnimation.GetComponent<ParticleSystem>().enableEmission = false;
    }

    

    private void GetDistanceTraveled()
    {
        distanceTraveled = transform.position.y - startingPositionY;
    }
    

}//class
