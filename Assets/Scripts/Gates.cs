using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public int Value;
    // Start is called before the first frame update
    void Start()
    {
        Randomm(1, 12);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int Randomm(int a, int b)
    {
       
        Value = Random.Range(a, b);
        return Value;
    }
}
