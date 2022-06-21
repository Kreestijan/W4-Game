using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAfter : MonoBehaviour
{
    public GameObject child;

    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Invoke("TransformP", 3f);
    }
    
    void TransformP()
    {
        child.transform.SetParent(parent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
