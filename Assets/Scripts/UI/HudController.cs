using UnityEngine;
using UnityEngine.UI;
using FishNet.Object;

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
        playerCountText.text = $"Online: {playerCount}";
    }

    [ServerRpc(RequireOwnership = false)]
    private void ServerUpdateAlivePlayersCountText()
    {
        ObserversUpdateAlivePlayersCountText(GameManager.Instance.alivePlayers);
    }

    [ObserversRpc]
    private void ObserversUpdateAlivePlayersCountText(int alivePlayerCount)
    {
        alivePlayersCountText.text = $"Alive: {alivePlayerCount}";
    }

}//class
