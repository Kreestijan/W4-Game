using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController :MonoBehaviour
{
    public GameObject[] Intercept;
    int len;
    Trigger_Spawn act;
    public GameObject[] Explozii;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    
    // Update is called once per frame
    void Update()
    {
        
      
        Debug.Log(Intercept.Length);
        ControllExplosion();

    }

     void ControllExplosion()
    {
        if (len == 0)
        {
            Explozii[3].SetActive(false);
            Explozii[0].SetActive(true);

        }
        else if (Intercept.Length != 0  && Intercept.Length <= 4)
        {

            Explozii[0].SetActive(false);
            Explozii[1].SetActive(true);
        }
        else if (Intercept.Length != 0 && Intercept.Length <= 8)
        {

            Explozii[1].SetActive(false);
            Explozii[2].SetActive(true);
        }
        else if (Intercept.Length != 0 && Intercept.Length <= 15)
        {

            Explozii[2].SetActive(false);
            Explozii[3].SetActive(true);
        }


    }
}
