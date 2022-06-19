using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trigger_Spawn : MonoBehaviour

{
    private Gates demo;
    public int totalShips = 0;
    [SerializeField] GameObject[] controller;
    [SerializeField] GameObject spawnerCTRL;
    [SerializeField] GameObject mainShip;
    int activeShips;
    public GameObject effect;

    PowerUps shieldScript;
    [SerializeField] GameObject shield;

    Player playerScript;
    [SerializeField] GameObject player;    

    // Start is called before the first frame update
    void Awake()
    {
        shieldScript = shield.GetComponent<PowerUps>();
        playerScript = player.GetComponent<Player>();
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
                    
                    totalShips += demo.Value;
                    totalShips = (int)Mathf.Clamp(totalShips, 0, Mathf.Infinity);
                    activeShips = totalShips;
                    activeShips = Mathf.Clamp(activeShips, 0, 15);
                    //Debug.Log(" TRIGGER () current contor is ======" + activeShips);
                    foreach (int i in Enumerable.Range(0, activeShips))
                    { controller[i].SetActive(true);
                        //effects[i].GetComponent;
                        }

                    Destroy(GameObject.FindGameObjectWithTag("+"));
                    Destroy(GameObject.FindGameObjectWithTag("-"));
                    break;
                }

            case "-":
                {
                    GameObject deer = collision.gameObject;
                    demo = deer.GetComponent<Gates>();
                    
                    /*if(playerScript.isShielded == true)
                    {
                        playerScript.isShielded = false;
                    }
                    else
                    {
                        totalShips -= demo.Value;
                    }*/
                    
                    totalShips -= demo.Value;
                    totalShips = (int)Mathf.Clamp(totalShips, 0, Mathf.Infinity);
                    activeShips = totalShips;
                    activeShips = Mathf.Clamp(activeShips, 0, 15);
                    foreach (int i in Enumerable.Range(0, 15))
                        controller[i].SetActive(false);
                    foreach (int i in Enumerable.Range(0, activeShips))
                        controller[i].SetActive(true);
                    Destroy(GameObject.FindGameObjectWithTag("+"));
                    Destroy(GameObject.FindGameObjectWithTag("-"));
                    break;

                }
        }
    }
    
    
}
