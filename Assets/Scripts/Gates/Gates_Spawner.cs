using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] gateReference;

    private GameObject gateSpawned1;
    private GameObject gateSpawned2;
    private int randomIndex;
    private double chance;

    private Vector2 target1;
    private Vector2 target2;
    void Start()
    {
        StartCoroutine(SpawnGates());
    }

    private IEnumerator SpawnGates()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            while (Player.instance.isPlayerDead == false)
            {

                chance = Random.Range(0, 2);


                if (chance == 0)
                {
                    
                    target1 = new Vector2(this.transform.position.x - 4.8f, this.transform.position.y);
                    target2 = new Vector2(this.transform.position.x + 4.8f, this.transform.position.y);

                  
                    gateSpawned1 = Instantiate(gateReference[0]);
                    gateSpawned2 = Instantiate(gateReference[1]);
                    gateSpawned1.transform.position = target1;
                    gateSpawned2.transform.position = target2;


                }
                else if (chance == 1)
                {
                    
                    target1 = new Vector2(this.transform.position.x - 4.8f, this.transform.position.y);
                    target2 = new Vector2(this.transform.position.x + 4.8f, this.transform.position.y);

                    gateSpawned1 = Instantiate(gateReference[1]);
                    gateSpawned2 = Instantiate(gateReference[0]);
                    gateSpawned1.transform.position = target1;
                    gateSpawned2.transform.position = target2;
                }
                yield return new WaitForSeconds(5f);
            }
        }
    }
}



