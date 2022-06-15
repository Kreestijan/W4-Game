using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowingBulletPlayer : MonoBehaviour
{
    public float speed;
    GameObject[] Intercept;
    Transform player;
    int randValue;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Intercept = GameObject.FindGameObjectsWithTag("Interceptor");
        if (Intercept.Length > 0)
            randValue = Random.Range(0, Intercept.Length);
        {
            transform.position = Vector2.MoveTowards(transform.position, Intercept[randValue].transform.position, speed * Time.deltaTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Intercept.Length == 0)
        {
            Debug.Log("Un elem");
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Intercept.Length >= 1 )
        { 
            transform.position = Vector2.MoveTowards(transform.position, Intercept[randValue].transform.position, speed * Time.deltaTime);
            if(Intercept[randValue].activeSelf==false)
            {
                Destroy(gameObject);
            }
        }

    }
}
