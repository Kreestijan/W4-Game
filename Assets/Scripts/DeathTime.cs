using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTime : MonoBehaviour
{
    public float Death_Time;
  
    void Start()
    {
        StartCoroutine(Wait(Death_Time));
        
    }

    IEnumerator Wait(float a)
    {
        
        yield return new WaitForSeconds(a); 
        Destroy(gameObject);
    }
  
    
}
