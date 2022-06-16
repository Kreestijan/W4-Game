using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public sealed class HudController : NetworkBehaviour
{
    [SerializeField] private Text playerCountText;
    
    [SerializeField] private Text alivePlayersCountText;

    private void Update()
    {
        ServerUpdatePlayerCountText();
        ServerUpdateAlivePlayersCountText();
    }

    [ServerRpc(RequireOwnership = false)]
    private void ServerUpdatePlayerCountText()
    {
        ObserversUpdatePlayerCountText(ServerManager.Clients.Count);
    }

    [ObserversRpc]
    private void ObserversUpdatePlayerCountText(int playerCount)
    {
        playerCountText.text = $"Online Players: {playerCount}";
    }

    [ServerRpc(RequireOwnership = false)]
    private void ServerUpdateAlivePlayersCountText()
    {
        ObserversUpdateAlivePlayersCountText(999);
    }

    [ObserversRpc]
    private void ObserversUpdateAlivePlayersCountText(int alivePlayerCount)
    {
        alivePlayersCountText.text = $"Alive Players: {alivePlayerCount}";
    }

}//class
