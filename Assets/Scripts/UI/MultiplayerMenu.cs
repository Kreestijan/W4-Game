using UnityEngine;
using UnityEngine.UI;
using FishNet;
using FishNet.Transporting.Tugboat;

public sealed class MultiplayerMenu : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button joinButton;
    [SerializeField] private InputField ipAddressField;

    private void Start()
    {
        hostButton.onClick.AddListener(() =>
        {
            InstanceFinder.ServerManager.StartConnection();

            InstanceFinder.ClientManager.StartConnection();
        });

        joinButton.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(ipAddressField.text))
            {
                InstanceFinder.TransportManager.GetComponent<Tugboat>().SetClientAddress("127.0.0.1");
            }
            else
            {
                InstanceFinder.TransportManager.GetComponent<Tugboat>().SetClientAddress(ipAddressField.text);
            }

            InstanceFinder.ClientManager.StartConnection();
        });

    }
    
}//class
