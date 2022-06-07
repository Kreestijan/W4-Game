using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 velocity;
    public float enemyHP;

    public bool canCollide = true;
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame

    
    void UpdateEnemyPosition()
    {
        Vector3 position = transform.localPosition;
        position.y -= velocity.y * Time.deltaTime;
        transform.localPosition = position;
    }
    void Update()
    {
        UpdateEnemyPosition();
    }
}
