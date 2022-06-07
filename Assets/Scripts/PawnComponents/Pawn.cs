using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;

public sealed class Pawn : NetworkBehaviour
{
    [SyncVar] public BRPlayer controllingPlayer;

    [SyncVar] public float health;


}//class
