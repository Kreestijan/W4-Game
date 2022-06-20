using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsVsEnemy : MonoBehaviour
{
    public float speed=10;
    Transform player;
    public float ShootingRange = 10.5f;
    public GameObject bullet;
    public GameObject bulletInst;
    public float nextShot;
    public float fireRate = 1.001f;
    Vector2 Direction;
    public GameObject navaPlayer;
    public Transform TargetEnemy;

    void Start()
    {
        
    }
    
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Enemy").transform;

        Vector2 targetPos = TargetEnemy.position;
        Direction =  (Vector2)transform.position-targetPos;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        //navaPlayer.transform.up = Direction * Time.deltaTime;
        if (distanceFromPlayer <= ShootingRange && nextShot < Time.time)
        {

            Instantiate(bullet, bulletInst.transform.position, Quaternion.identity);
            nextShot = Time.time + .4001f;

        }
            
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
