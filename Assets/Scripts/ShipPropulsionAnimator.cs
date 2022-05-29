using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPropulsionAnimator : MonoBehaviour
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

    private void FixedUpdate()
    {
        PlayerAnimation();
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
    
}//clas
