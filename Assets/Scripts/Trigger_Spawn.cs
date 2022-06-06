using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trigger_Spawn : MonoBehaviour

{
    private Gates demo;
    private int totalShips = 0;
    [SerializeField] GameObject[] controller;
    [SerializeField] GameObject spawnerCTRL;
    [SerializeField] GameObject mainShip;
    int activeShips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string TAG = collision.gameObject.tag;
        switch (TAG)
        {
            case "+":
                {
                    GameObject deer = collision.gameObject;
                    demo = deer.GetComponent<Gates>();
                    Debug.Log("+ value is ++++++++++" + demo.Value);
                    totalShips += demo.Value;
                    activeShips = totalShips;
                    activeShips = Mathf.Clamp(activeShips, 0, 15);
                    Debug.Log(" total ships are ======" + totalShips);
                    Debug.Log(" current activeShips is ======" + activeShips);
                    //Debug.Log(" TRIGGER () current contor is ======" + activeShips);
                    foreach (int i in Enumerable.Range(0, activeShips))
                        controller[i].SetActive(true);

                    Destroy(collision.gameObject);
                    break;
                }

            case "-":
                {
                    GameObject deer = collision.gameObject;
                    demo = deer.GetComponent<Gates>();
                    Debug.Log("- value is ----------" + demo.Value);
                    totalShips -= demo.Value;
                    activeShips = totalShips;
                    activeShips = Mathf.Clamp(activeShips, 0, 15);
                    Debug.Log(" total ships are ======" + totalShips);
                    Debug.Log(" current activeShips is ======" + activeShips);
                    foreach (int i in Enumerable.Range(0, 15))
                        controller[i].SetActive(false);
                    foreach (int i in Enumerable.Range(0, activeShips))
                        controller[i].SetActive(true);
                    Destroy(collision.gameObject);
                    break;

                }
        }
    }
    
    /*void Check()
    {

        if(totalShips>0)
        {
            // activeShips = totalShips;
             int dif = totalShips - activeShips;
            Debug.Log(" current ships are ======" + dif);
            Debug.Log(" current contor is ======" + activeShips);


            if (totalShips>15)
            {
                foreach (int i in Enumerable.Range(0, activeShips-1))
                    controller[i].SetActive(true);
            }
            else if(totalShips<=15)
            {
                Mathf.Abs(dif);
                foreach (int i in Enumerable.Range(0, activeShips-1))
                    controller[i].SetActive(true);
                Debug.Log("DIF=====" + dif);
                    controller[dif].SetActive(false);
            }
            
        }
        else if (totalShips <= 0)
        {
            spawnerCTRL.SetActive(false);
            mainShip.SetActive(false);
        }
    }*/
}
