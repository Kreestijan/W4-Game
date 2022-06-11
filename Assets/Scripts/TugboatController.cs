using FishNet.Object;
using UnityEngine;
using UnityEngine.UI;
using FishNet.Transporting.Tugboat;

public sealed class TugboatController : NetworkBehaviour
{
    [SerializeField] private InputField ipAddressField;
    [SerializeField] private ushort port = 7770;

    private Tugboat transport;

    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        transport = GetComponent<Tugboat>();

        transport.SetClientAddress(ipAddressField.ToString());
        transport.SetPort(port);
    }






}//class
