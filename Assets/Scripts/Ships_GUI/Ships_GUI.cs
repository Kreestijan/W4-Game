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
        txt.text = ":" + no_ships;
        
    }

    
    void Update()
    {
        no_ships = script.totalShips;
        txt.text = ":"+no_ships;
        
    }
    
}
