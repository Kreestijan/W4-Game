using UnityEngine;
using FishNet.Object;

public class ShipPropulsionAnimator : NetworkBehaviour
{
    private readonly string turboAnimation = "isTurboON";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        animator.SetBool(turboAnimation, false);
    }

    private void Update()
    {
        if (!IsOffline)
        {
            if (!IsOwner) return;

            PlayerAnimation();
        }
        else PlayerAnimation();
    }

    void PlayerAnimation()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool(turboAnimation, true);
        }
        else
        {
            animator.SetBool(turboAnimation, false);
        }
    }
    
}//class
