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

    public bool fire;

    private Joystick joystick;

    
    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        _pawn = GetComponent<Pawn>();

        if (GameObject.FindWithTag("Joystick") != null)
        {
            joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
        }
    }

    private void Update()
    {
        if (!IsOwner) return;

        Debug.Log($"Platform: {Application.platform}");

        if (Application.platform == RuntimePlatform.Android && joystick != null)
        {
            horizontal = joystick.Horizontal;
            vertical = joystick.Vertical;

            if (Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Began)
            {
                fire = true;
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            turbo = Input.GetButton("Jump");

            if (Input.GetButtonDown("Fire1"))
            {
                fire = true;
            }
        }
    }
    

}//class
