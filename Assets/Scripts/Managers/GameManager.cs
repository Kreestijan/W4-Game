using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public sealed class GameManager : NetworkBehaviour
{
    public static GameManager Instance { get; private set; }

    [SyncObject] public readonly SyncList<BRPlayer> players = new();

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        Debug.Log($"Connected players: {players.Count}", this);
        
    }
}
