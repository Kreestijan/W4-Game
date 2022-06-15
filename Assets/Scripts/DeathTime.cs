using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTime : MonoBehaviour
{
    public float Death_Time;
   // public GameObject expl;
    // Start is called before the first frame update
    void Start()
    {
        /*var ob=expl.GetComponent<SpriteRenderer>();
        int LayerIgnoreRaycast = LayerMask.NameToLayer("UI");
        gameObject.layer = LayerIgnoreRaycast;
        ob.sortingLayerName("Actors");*/
        StartCoroutine(Wait(Death_Time));
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
