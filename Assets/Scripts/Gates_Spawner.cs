using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] gateReference;

    private GameObject gateSpawned;

    private int randomIndex;
    private double chance;

    private Vector2 target;

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

                chance = Random.Range(0,2);


                if (chance == 0)
                {
                    target = new Vector2(this.transform.position.x, this.transform.position.y);

                    //randomIndex = Random.Range(0, gateReference.Length);

                    gateSpawned = Instantiate(gateReference[0]);

                    gateSpawned.transform.position = target;
                }
                else if(chance==1)
                {
                    target = new Vector2(this.transform.position.x, this.transform.position.y);

                    //randomIndex = Random.Range(0, gateReference.Length);

                    gateSpawned = Instantiate(gateReference[1]);

                    gateSpawned.transform.position = target;
                }
                yield return new WaitForSeconds(5f);
            }
        }
    }



}
