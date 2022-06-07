using UnityEngine;
using FishNet.Object;
using System.IO.Pipes;

public sealed class PawnWeapon : NetworkBehaviour
{
    private Pawn _pawn;

    private PawnInput _input;

    private PawnAim _aim;

    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;
    [SerializeField] private float projectileSpeed;

    private float damage;

    [SerializeField] private Transform firePoint;

    private Vector2 shootingDirection;

    [SerializeField] private GameObject laserPrefab;

    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        _pawn = GetComponent<Pawn>();

        _input = GetComponent<PawnInput>();

        _aim = GetComponent<PawnAim>();
        

    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;


     
        if (_input.fire)
        {
            damage = Random.Range(minDamage, maxDamage);

            shootingDirection = new(_aim.aimDirection.x, _aim.aimDirection.y);

            Debug.Log("Shots fired!");
            
            ServerFire();

            _input.fire = false;
        }
     
    }

    [ServerRpc]
    private void ServerFire()
    {
        GameObject laserBeam = Instantiate(laserPrefab, firePoint.position, Quaternion.LookRotation(Vector3.forward, _aim.directionOfRotation));
        laserBeam.GetComponent<Rigidbody2D>().velocity = shootingDirection * projectileSpeed;
    }

}//class
