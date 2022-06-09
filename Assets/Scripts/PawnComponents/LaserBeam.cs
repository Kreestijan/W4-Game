using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using System.Runtime.CompilerServices;
using TMPro;

public sealed class LaserBeam : NetworkBehaviour
{
    [SerializeField] private float projectileSpeed;

    [SerializeField] private Rigidbody2D projectileBody;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!IsOwner) return;

        projectileBody.velocity = PawnWeapon.Instance.firePoint.up * projectileSpeed;
    }

    //[Server]
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //To handle collision...

    //Despawn();
    //}
}
