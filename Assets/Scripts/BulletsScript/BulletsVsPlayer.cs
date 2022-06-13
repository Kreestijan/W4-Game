using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class BulletsVsPlayer : MonoBehaviour
{
    public float speed=5;
    Transform player;
    GameObject [] Intercept;
    float lineofSight = 2f;
    public float ShootingRange = 10.5f;
    public GameObject bullet;
    public GameObject bulletInst;
    public float nextShot;
    public float fireRate = 1.001f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        

        /////////
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if(distanceFromPlayer<=ShootingRange && nextShot<Time.time)
        {
            Instantiate(bullet, bulletInst.transform.position,Quaternion.identity);
            nextShot = Time.time+.4001f ;
        }

    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, lineofSight);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
