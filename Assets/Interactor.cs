using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Interactor :MonoBehaviour
{
    private Gates demo;
    public int totalShips = 0;
    [SerializeField] GameObject[] controller;
    [SerializeField] GameObject spawnerCTRL;
    [SerializeField] GameObject mainShip;
    int activeShips;
    //public GameObject effect;
    //public GameObject animation;
    bool isShielded = false;
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

        //var anim = animation.GetComponent<ParticleSystem>();
        string TAG1 = collision.gameObject.tag;
        Debug.Log("Inamic");

        if (TAG1 == "Enemy")
        {
            Debug.Log("Inamic");
            GameObject collisionValue1 = collision.gameObject;
            demo = collisionValue1.GetComponent<Gates>();
            totalShips -= demo.Value;
            totalShips = (int)Mathf.Clamp(totalShips, 0, Mathf.Infinity);
            activeShips = totalShips;
            activeShips = Mathf.Clamp(activeShips, 0, 15);
            foreach (int i in Enumerable.Range(0, 15))
                controller[i].SetActive(false);
            foreach (int i in Enumerable.Range(0, activeShips))
                controller[i].SetActive(true);
           


        }
    }
}
