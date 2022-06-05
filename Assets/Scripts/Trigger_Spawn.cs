using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trigger_Spawn : MonoBehaviour

{

    private Gates demo;
    int tr = 1;
    private int currentShips=0;
    private int maxAppearShips=15;
    [SerializeField] GameObject []controller;
    [SerializeField] GameObject spawnerCTRL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Check();
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
                    // demo = GetComponent<Gates>();
                    //string TAG = collision.gameObject.tag;
                    Debug.Log("+ value is ++++++++++" + demo.Value);
                    currentShips += demo.Value;
                    Debug.Log(" current ships are ======" + currentShips);
                    
                    break;
                }

            case "-":
                {
                    GameObject deer = collision.gameObject;
                    demo = deer.GetComponent<Gates>();
                    Debug.Log("- value is ----------" + demo.Value);
                    currentShips -= demo.Value;
                    Debug.Log(" current ships are ======" + currentShips);
                    if (currentShips <= 0)
                        { currentShips = 0; }
                    break;
                    
                }
        }
    }

    void Check()
    {
        /*switch(currentShips)
        {
            case 0:
                {
                    tr += 1;
                    if (tr == 2)
                    {
                        player.objPlayer.SetActive(false);
                    }
                    break;
                }
            case 1:
                {
                    break;
                }
            case 2:
                {
                    foreach (int i in Enumerable.Range(0, 2))
                    {
                        controller[i].SetActive(true);
                    }

                    break;
                }
            case 3:
                {
                    foreach (int i in Enumerable.Range(0, 3))
                    {
                        controller[i].SetActive(true);
                    }
                    break;
                }
        }*/
        if (currentShips >=0)
        {
            int contor = currentShips;
            Debug.Log("Contorul este==== " + contor);
            int dif = currentShips - contor;
            Debug.Log("Diferenta este==== " + dif);
            if(dif==0)
            {
                foreach (int i in Enumerable.Range(0, currentShips))
                {
                    Debug.Log("=");
                    controller[i].SetActive(true);

                }

            }
            else if(dif<0)
            {
                foreach (int i in Enumerable.Range(0, dif))
                {
                    Debug.Log("<");
                    controller[i].SetActive(true);

                }
            }

            else if(dif>0)
            {

                foreach (int i in Enumerable.Range(0, dif))
                {
                    Debug.Log(">");
                    controller[i].SetActive(false);

                }
            }
            /*if (currentShips <= maxAppearShips)
                foreach (int i in Enumerable.Range(0, demo.Value))
                {

                    controller[i].SetActive(true);

                }*/
            
        }

        /*else if (currentShips> 0 && currentShips < 15)
        {
            int dif = currentShips-maxAppearShips  ;

            Debug.Log("The difference between the current ships is " + dif);
            
            
            dif = Mathf.Abs(dif);
            foreach (int i in Enumerable.Range(0, dif))
            {
              controller[i].SetActive(false);
            }*/
                /*foreach (int i in Enumerable.Range(0, currentShips))
                {
                    controller[i].SetActive(false);
                }*/
            
           /* else if (dif > 0)
            {

                foreach (int i in Enumerable.Range(0, dif))
                {
                    controller[i].SetActive(false);
                }
                foreach (int i in Enumerable.Range(0, currentShips))
                {
                    controller[i].SetActive(true);
                }

            }*/

        }
        /*else if (currentShips==0)
        {
            tr -= 1;
        }
        else if (currentShips ==0 && tr==0)
        {
            currentShips = 0;
            //player.objPlayer.SetActive(false);
            spawnerCTRL.SetActive(false);
        }*/

    }

