using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject shieldRef;
    //other powerups here

    public GameObject shieldOnScreen;


    private double chance;

    private Vector2 target;

    void Start()
    {
        StartCoroutine(SpawnShield());
    }

    private IEnumerator SpawnShield()
    {
            while (GameObject.FindWithTag("Player") != null)
            {
                

               
                    target = new Vector2(Random.Range(-7, 7), this.transform.position.y);

                    shieldOnScreen = Instantiate(shieldRef);


                    shieldOnScreen.transform.position = target;
                
                yield return new WaitForSeconds(5f);
            }
    }
}
