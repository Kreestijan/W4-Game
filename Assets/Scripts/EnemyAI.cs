using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 velocity;
    public float enemyHP;
    Player playerScript;
    GameObject player;
    public bool canCollide = true;

    private void Awake()
    {
        playerScript = player.GetComponent<Player>();
    }
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame

    
    void UpdateEnemyPosition()
    {
        
        Vector3 position = transform.localPosition;
        /*velocity.x = playerScript.movementX*playerScript.moveSpeed;
        position.x = velocity.x* Time.deltaTime;*/
       // position.y -= velocity.y * Time.deltaTime;
        transform.localPosition = position;
    }
    void Update()
    {
        UpdateEnemyPosition();
    }
}
