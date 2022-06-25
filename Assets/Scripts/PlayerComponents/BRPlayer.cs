using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine.AddressableAssets;
using FishNet.Connection;

public sealed class BRPlayer : NetworkBehaviour
{

    public static BRPlayer Instance { get; private set; }

    [SyncVar] public string nickname;

    [SyncVar] public bool isReady; 

    [SyncVar] public Pawn controlledPawn;

    

    public override void OnStartServer()
    {
        base.OnStartServer();

        GameManager.Instance.players.Add(this);
    }

    public override void OnStopServer()
    {
        base.OnStopServer();

        GameManager.Instance.players.Remove(this);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!IsOwner) return;

        Instance = this;

        UIManager.Instance.Initialize();

        UIManager.Instance.Show<LobbyView>();
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ServerSetIsReady(!isReady);
            Debug.Log("You've pressed R!");
        }

    }

    public void StartGame()
    {
        GameObject pawnPrefab = Addressables.LoadAssetAsync<GameObject>("Pawn").WaitForCompletion();
        GameObject pawnInstance = Instantiate(pawnPrefab);

        pawnPrefab.transform.position = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.value);

        Spawn(pawnInstance, Owner);

        controlledPawn = pawnInstance.GetComponent<Pawn>();

        controlledPawn.controllingPlayer = this;

        TargetPawnSpawned(Owner);

        GameManager.Instance.alivePlayers++;
    }

    
    public void StopGame()
    {
        if (controlledPawn != null && controlledPawn.IsSpawned)
        {
            controlledPawn.Despawn();
        }            
    }
    
    [ServerRpc(RequireOwnership = false)]
    public void Respawn()
    {
        StartGame();
    }

    [ServerRpc(RequireOwnership = false)] 
    public void ServerSetIsReady(bool value)
    {
        isReady = value;
    }

    [TargetRpc]
    private void TargetPawnSpawned(NetworkConnection networkConnection)
    {
        UIManager.Instance.Show<MainView>();
    }

    [TargetRpc]
    public void TargetPawnKilled(NetworkConnection networkConnection)
    {
        UIManager.Instance.Show<RespawnView>();
    }
    
}//class
