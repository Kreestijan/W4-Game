using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Transporting;
using System;

public class PlayerNameTracker : NetworkBehaviour
{
    //Called when any player changes their name
    public static event Action<NetworkConnection, string> OnNameChange;

    //Collection of each player name for connections
    [SyncObject]
    private readonly SyncDictionary<NetworkConnection, string> _playerNames = new SyncDictionary<NetworkConnection, string>();

    //Singleton instance of this object
    private static PlayerNameTracker _instance;

    private void Awake()
    {
        _instance = this;
        _playerNames.OnChange += _playerNames_OnChange;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState += ServerManager_OnRemoteConnectionState;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState -= ServerManager_OnRemoteConnectionState;
    }

    //Called when a remote connection state changes
    private void ServerManager_OnRemoteConnectionState(NetworkConnection arg1, FishNet.Transporting.RemoteConnectionStateArgs arg2)
    {
        if (arg2.ConnectionState != RemoteConnectionStates.Started)
        {
            _playerNames.Remove(arg1);
        }
    }
    
    //Optional callback when the playerNames collection changes
    private void _playerNames_OnChange(SyncDictionaryOperation op, NetworkConnection key, string value, bool asServer)
    {
        if (op == SyncDictionaryOperation.Add || op == SyncDictionaryOperation.Set)
            OnNameChange?.Invoke(key, value);
    }

    //Gets a player name. Works on server or client
    public static string GetPlayerName(NetworkConnection conn)
    {
        if (_instance._playerNames.TryGetValue(conn, out string result))
            return result;
        else
            return string.Empty;
    }

    //Lets clients set their nickname
    [Client]
    public static void SetName(String name)
    {
        _instance.ServerSetName(name);
    }

    //Sets name on server
    [ServerRpc(RequireOwnership = false)]
    private void ServerSetName(string name, NetworkConnection sender = null)
    {
        _playerNames[sender] = name;
    }


}//class
