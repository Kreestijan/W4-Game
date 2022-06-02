using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] planetReference;

    private GameObject spawnedPlanet;

    private int randomIndex;
    private double chance;

    private Vector2 target;

    void Start()
    {
        StartCoroutine(SpawnPlanets());
    }

    private IEnumerator SpawnPlanets()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            while (Player.instance.isPlayerDead == false)
            {

                chance = Random.value;


                if (chance > 0.40f)
                {
                    target = new Vector2(Random.Range(-7, 7), this.transform.position.y);

                    randomIndex = Random.Range(0, planetReference.Length);

                    spawnedPlanet = Instantiate(planetReference[randomIndex]);

                    spawnedPlanet.transform.position = target;
                }

                yield return new WaitForSeconds(25f);
            }
        }
    }
    
}//class
