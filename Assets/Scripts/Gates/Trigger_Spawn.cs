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
    //public GameObject effect;
    public GameObject animation;
    bool isShielded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActiveShips();


    }
    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(3f);

    }
    int ActiveShips()
    { return activeShips; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var anim = animation.GetComponent<ParticleSystem>();
        string TAG = collision.gameObject.tag;
        switch (TAG)
        {
            case "+":
                {
                    GameObject collisinValue = collision.gameObject;
                    demo = collisinValue.GetComponent<Gates>();
                    totalShips += demo.Value;
                    totalShips = (int)Mathf.Clamp(totalShips, 0, Mathf.Infinity);
                    activeShips = totalShips;
                    activeShips = Mathf.Clamp(activeShips, 0, 15);
                    foreach (int i in Enumerable.Range(0, activeShips))
                    { 
                        controller[i].SetActive(true);
                    }

                    Destroy(GameObject.FindGameObjectWithTag("+"));
                    Destroy(GameObject.FindGameObjectWithTag("-"));
                    break;
                }

            case "-":
                {
                    GameObject deer = collision.gameObject;
                    demo = deer.GetComponent<Gates>();
                    if (isShielded == false)
                    {
                        anim.Stop();
                        totalShips -= demo.Value;
                        
                    }
                    else if (isShielded==true)
                    {
                        totalShips = totalShips;
                        isShielded = false;
                        anim.Stop();

                    }
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

            case "Shield":
                {
                    isShielded = true;
                    DeathTimer();
                    Destroy(GameObject.FindGameObjectWithTag("Shield"));
                    collision.gameObject.SetActive(true);
                    anim.Play();
                    break;
                }
            case "Kill":
                {
                    //collision.gameObject.SetActive(false);
                    DeathTimer();
                    Destroy(collision.gameObject);
                    break;
                }
            case "Enemy":
                {


                }
        }
    }
    
    
}
