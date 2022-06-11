using UnityEngine;
using FishNet.Object;

public class PawnWeapon : NetworkBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    public Transform firePoint;

    private PawnInput _input;

    public static PawnWeapon Instance { get; private set; }

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!IsOwner) return;

        Instance = this;
    }
    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        _input = GetComponent<PawnInput>();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        if (_input.fire)
        {
            ServerFire();

            _input.fire = false;
        }

    }

    [ServerRpc]
    public void ServerFire()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Spawn(projectileInstance, Owner);
    }

}//class
