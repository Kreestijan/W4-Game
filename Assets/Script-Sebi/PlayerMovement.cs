using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    string bro;
    int bro1;
    private Rigidbody2D mybody;
    private float miscare_X;
    private float miscare_Y;
    public GameObject player;
    [SerializeField] private float moveForce;
    String[] operation;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Input_Miscare();
        

    }
    void Input_Miscare()
    {
        float miscare_X = Input.GetAxisRaw("Horizontal");
        float miscare_Y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(miscare_X, miscare_Y, 0) * Time.deltaTime * moveForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        Destroy(collision.gameObject);
        bro = collision.gameObject.tag;
        Debug.Log(bro.GetType());
        // Taking a string
        Operatii();

        
      
    }

    void Operatii()
    {

        char[] spearator = { ' ' };

        // using the method
        String[] strlist = bro.Split(spearator);

        foreach (String s in strlist)
        {
            Debug.Log("The elements are : \n" + s);
        }
        Debug.Log("sa vede");
        Debug.Log(strlist[1]);


        if (strlist[0] == "+")
        {
            for (var i = 0; i <= Int16.Parse(strlist[1]);i++)
                Instantiate(player);

        }
        
    }
}
