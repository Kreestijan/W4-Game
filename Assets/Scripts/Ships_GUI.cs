using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ships_GUI : MonoBehaviour
{

    public TextMeshProUGUI txt;
    private int no_ships=0;
    private Trigger_Spawn Total_ships;
    
    // Start is called before the first frame update
    void Start()
    {

        txt.text = "Score : " + no_ships;
        
    }

    
    void Update()
    {
        /*Total_ships = gameObject.GetComponent<Trigger_Spawn>();
        //Tota
        txt.text = "Score : " + no_ships;*/
        
    }
    
}
