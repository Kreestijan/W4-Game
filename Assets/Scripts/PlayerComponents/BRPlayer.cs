using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine.AddressableAssets;

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
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ServerSetIsReady(!isReady);
            Debug.Log("You've pressed R!");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            
        }

    }

    public void StartGame()
    {
        GameObject pawnPrefab = Addressables.LoadAssetAsync<GameObject>("Pawn").WaitForCompletion();
        GameObject pawnInstance = Instantiate(pawnPrefab);

        Spawn(pawnInstance, Owner);

        controlledPawn = pawnInstance.GetComponent<Pawn>();
    }
    
    public void StopGame()
    {
        if (controlledPawn != null && controlledPawn.IsSpawned) controlledPawn.Despawn();
    }

    [ServerRpc(RequireOwnership = false)] 
    public void ServerSetIsReady(bool value)
    {
        isReady = value;
    }


}//class
