using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetText : MonoBehaviour
{
    public TextMeshPro text;
    public GameObject gate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTextBox();
    }
    void UpdateTextBox()
    {
        var gs = gate.GetComponent<Gates>();
        text.text = gs.Value.ToString();
       
    }
}
