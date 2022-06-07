using FishNet.Object;
using UnityEngine;

public sealed class PawnInput : NetworkBehaviour
{
    private Pawn _pawn;

    public float horizontal;
    public float vertical;

    public float mouseX;
    public float mouseY;

    public float sensitivity;

    public bool turbo;


    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        _pawn = GetComponent<Pawn>();
    }

    private void Update()
    {
        if (!IsOwner) return;
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        turbo = Input.GetButton("Jump");

    }
    

}//class
