using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class BulletsVsPlayer : MonoBehaviour
{
    public float speed=5;
    Transform player;
    public float ShootingRange = 10.5f;
    public GameObject bullet;
    public GameObject bulletInst;
    public float nextShot;
    public float fireRate = 1.001f;
    Vector2 Direction;
    public GameObject navaEnemy;
    public Transform TargetPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        Vector2 targetPos = TargetPlayer.position;
        Direction = targetPos - (Vector2)transform.position;
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        navaEnemy.transform.up = Direction * Time.deltaTime; 
        if (distanceFromPlayer<=ShootingRange && nextShot<Time.time)
        {
            Instantiate(bullet, bulletInst.transform.position,Quaternion.identity);
            nextShot = Time.time+.4001f ;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
