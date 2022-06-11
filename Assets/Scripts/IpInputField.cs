using FishNet;
using FishNet.Transporting;
using FishNet.Transporting.Tugboat;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IpInputField : MonoBehaviour
{
    private InputField ipAddressField;

    private void Start()
    {
        ipAddressField = GetComponent<InputField>();
    }

    public void SetTugBoatAddress()
    {
        InstanceFinder.TransportManager.GetComponent<Tugboat>().SetClientAddress(ipAddressField.text);
    }

    
}//class
