using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;

public sealed class LaserBeam : NetworkBehaviour
{
    [SerializeField] private float projectileSpeed;

    [SerializeField] private Rigidbody2D projectileBody;

    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;

    private float damage;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!IsOwner) return;

        projectileBody.velocity = PawnWeapon.Instance.firePoint.up * projectileSpeed;
    }

    private void FixedUpdate()
    {
        Invoke(nameof(SelfDestruct), 10.0f);
    }

    [ServerRpc]
    private void SelfDestruct()
    {
        Despawn();
    }

    [Server]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (IsSpawned && collision.gameObject.CompareTag("Pawn"))
        {
            
            damage = Random.Range(minDamage, maxDamage);

            Debug.Log($"Damage: {damage}");

            collision.gameObject.GetComponent<Pawn>().TakeDamage(damage);

            Despawn();
        }
    }
}
