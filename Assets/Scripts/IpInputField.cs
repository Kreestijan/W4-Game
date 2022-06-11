using FishNet;
using FishNet.Transporting.Tugboat;
using UnityEngine;
using UnityEngine.UI;

public class IpInputField : MonoBehaviour
{
    private InputField ipAddressField;

    private void Start()
    {
        ipAddressField = GetComponent<InputField>();
    }

    public void SetTugboatAddress()
    {
        InstanceFinder.TransportManager.GetComponent<Tugboat>().SetClientAddress(ipAddressField.text);
    }

    
}//class
