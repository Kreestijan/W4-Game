using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTravelledController : MonoBehaviour
{

    public static DistanceTravelledController instance;

    public Text distanceCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        distanceCounter.text = "x00000m";
    }

    private void FixedUpdate()
    {
        UpdateDistance();
        Debug.Log(Player.instance.distanceTraveled);
    }

    public void UpdateDistance()
    {
        if (GameObject.FindWithTag("Player") != null) distanceCounter.text = $"x{Player.instance.distanceTraveled:F2}m";
        
    }

}//class