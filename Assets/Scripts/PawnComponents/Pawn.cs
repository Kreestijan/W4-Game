using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public sealed class Pawn : NetworkBehaviour
{
    [SyncVar] public BRPlayer controllingPlayer;

    [SyncVar] public float health;

    public void ReceiveDamage(float amount)
    {
        if (!IsSpawned) return;

        if((health -= amount) <= 0.0f)
        {
            Despawn();
        }
    }


}//class
