using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public sealed class HudController : NetworkBehaviour
{
    [SerializeField]
    private Text playerCountText;

    private void Update()
    {
                        

        if(IsHost) this.GiveOwnership(LocalConnection);

        if (!IsOwner) return;
        
        ServerUpdatePlayerCountText();
    }

    [ServerRpc]
    private void ServerUpdatePlayerCountText()
    {
        ObserversUpdatePlayerCountText(ServerManager.Clients.Count);
    }

    [ObserversRpc]
    private void ObserversUpdatePlayerCountText(int playerCount)
    {
        playerCountText.text = $"Online Players: {playerCount}";
    }
}