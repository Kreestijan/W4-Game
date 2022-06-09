using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTime : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(1.5f));
    }

    IEnumerator Wait(float a)
    {
        yield return new WaitForSeconds(a); //Wait two seconds
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
