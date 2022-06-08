using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine.AddressableAssets;

public sealed class PawnWeapon : NetworkBehaviour
{
    private Pawn _pawn;

    private PawnInput _input;

    private PawnAim _aim;

    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;
    [SerializeField] private float projectileSpeed;

    private Rigidbody2D laserBody;

    private float damage;

    [SerializeField] private Transform firePoint;

    [SyncVar] private Vector2 shootingDirection;

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

    [ServerRpc(RequireOwnership = false)]
    private void ServerFire()
    {
        GameObject laserBeamInstance = Instantiate(laserPrefab, firePoint.position, Quaternion.LookRotation(Vector3.forward, _aim.directionOfRotation));

        Spawn(laserBeamInstance, Owner);

        laserBody = laserBeamInstance.GetComponent<Rigidbody2D>();

        laserBody.velocity = shootingDirection * projectileSpeed;
    }

    [ObserversRpc]
    private void ObserverFire()
    {

    }

}//class
