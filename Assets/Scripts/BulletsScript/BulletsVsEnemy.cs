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
    public GameObject navaPlayer;
    public Transform TargetEnemy;
    GameObject player1;
    int valoareShip;
    GameObject instance;

    void Start()
    {
        //nrCurentShips = total.totalShips;
    }
    
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Enemy").transform;
        player1 = GameObject.FindGameObjectWithTag("Enemy");
        Vector2 targetPos = TargetEnemy.position;
       
        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        
        if (distanceFromPlayer <= ShootingRange && nextShot < Time.time )
        {
            if (player1 != false)
            {
                var valueShip = player1.GetComponent<Gates>();
                valoareShip = valueShip.Value;
                Debug.Log("valoare valoareShip  " + valoareShip);
          
                //nrCurentShips = -valoareShip;
                instance=Instantiate(bullet, bulletInst.transform.position, Quaternion.identity);
                nextShot = Time.time + .4001f;
            } 

        }
         if (TargetEnemy.position==null) 
        {
            Debug.Log("no enemy============");
            Destroy(instance);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
