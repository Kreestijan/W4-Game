using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LaserBeam : MonoBehaviour
{
    [SerializeField] private Vector2 velocity = new(0.0f, 0.0f);
    
    private void Update()
    {
        Vector2 currentPosition = new (transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        RaycastHit2D[] hits = Physics2D.LinecastAll(currentPosition, newPosition);
        
        foreach(RaycastHit2D hit in hits)
        {
            Debug.Log(hit.collider.gameObject);
        }

        transform.position = newPosition;
    }
}
