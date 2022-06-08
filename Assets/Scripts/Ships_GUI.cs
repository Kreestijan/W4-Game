using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ships_GUI : MonoBehaviour
{

    public TextMeshProUGUI txt;
    private int no_ships=0;
    
    public Trigger_Spawn script;
    
    // Start is called before the first frame update
    void Start()
    {
        no_ships = script.totalShips;
        Debug.Log("no_ships is "+no_ships);
        txt.text = "Score : " + no_ships;
        
    }

    
    void Update()
    {
        no_ships = script.totalShips;
        /*Total_ships = gameObject.GetComponent<Trigger_Spawn>();
        //Tota*/
        txt.text = ":"+no_ships;
        
    }
    
}
