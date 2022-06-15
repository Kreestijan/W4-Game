using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazaExplozii : MonoBehaviour
{
    public GameObject prefab;
    public float a = 1.5f;
    public float b = 3.5f;
    public Transform x1;
    public Transform x2;
    public Transform y1;
    public Transform y2;
    GameObject pr;
    
    // Start is called before the first frame update
    void Start()
    {
        

        InvokeRepeating("Spawn", 2, 1);
        InvokeRepeating("Spawn", 2, 1.5f);
        InvokeRepeating("Spawn", 2, 1.2f);
    }

    private void Update()
    {
        
        
    }
    // Update is called once per frame
     void Spawn()
    {
        
        Vector3 vector = new Vector3(Random.Range(x1.position.x, x2.position.x), Random.Range(y1.position.y, y2.position.y), transform.position.z);
        var explozie = Instantiate(prefab, vector, Quaternion.identity);
        explozie.transform.parent = gameObject.transform;
        
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2(a,b));

    }
}
