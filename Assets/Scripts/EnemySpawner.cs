using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyRef;

    public GameObject enemyOnScreen;
    public Transform EnemyList;
    private double chance;
    private Vector2 target;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        
    }

    private IEnumerator SpawnEnemies()
    {
            while (GameObject.FindWithTag("Player") != null)
            {
                

                    target = new Vector2(Random.Range(-7, 7), this.transform.position.y);

                    enemyOnScreen = Instantiate(enemyRef);
                    enemyOnScreen.transform.SetParent(EnemyList);
                    enemyOnScreen.transform.position = target;
                
                yield return new WaitForSeconds(10f);
            }
    }
    
}
