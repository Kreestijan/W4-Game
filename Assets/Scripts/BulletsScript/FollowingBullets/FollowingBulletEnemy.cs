using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBulletEnemy : MonoBehaviour
{
    public float speed;
    Transform player;
    GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Enemy").transform;
        playerObj = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()

    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if(transform.position==player.position)
        {
            Destroy(gameObject);
        }
        
    }
}

