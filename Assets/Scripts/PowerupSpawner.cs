using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject shieldRef;
    //other powerups here
    [SerializeField] private GameObject killRef;
    public GameObject shieldOnScreen;

    public GameObject killPowerOnScreen;

    private double chance;

    private Vector2 target;

    void Start()
    {
        StartCoroutine(SpawnShield());
        StartCoroutine(SpawnKillPower());
    }

    private IEnumerator SpawnShield()
    {
            while (GameObject.FindWithTag("Player") != null)
            {
                

               
                    target = new Vector2(Random.Range(-7, 7), this.transform.position.y);

                    shieldOnScreen = Instantiate(shieldRef);


                    shieldOnScreen.transform.position = target;
                
                yield return new WaitForSeconds(9f);
            }
    }

    private IEnumerator SpawnKillPower()
    {
        while (GameObject.FindWithTag("Player") != null)
            {
                

               
                    target = new Vector2(Random.Range(-7, 7), this.transform.position.y);

                    killPowerOnScreen = Instantiate(killRef);


                    killPowerOnScreen.transform.position = target;
                
                yield return new WaitForSeconds(7f);
            }
    }
}
