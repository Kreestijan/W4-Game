using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine.AddressableAssets;

public sealed class BRPlayer : NetworkBehaviour
{
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
            ServerSpawnPawn();
        }

    }

    [ServerRpc] 
    public void ServerSetIsReady(bool value)
    {
        isReady = value;
    }

    [ServerRpc]
    private void ServerSpawnPawn()
    {
        GameObject pawnPrefab = Addressables.LoadAssetAsync<GameObject>("Pawn").WaitForCompletion();
        GameObject pawnInstance = Instantiate(pawnPrefab);

        Spawn(pawnInstance, Owner);
    }



}//class
