using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using FishNet.Object;

public class PawnAim : NetworkBehaviour
{   
    [HideInInspector] public Vector2 directionOfRotation;
    private Vector3 mousePosition;
    [HideInInspector] public Vector3 aimDirection;

    private float rotationSpeed = 900f;

    private PawnInput _input;

    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        _input = GetComponent<PawnInput>();
        
    }

        private void Update()
    {
        if(!IsOwner) return;

        if (Application.platform == RuntimePlatform.Android)
        {
            directionOfRotation = new(_input.horizontal, _input.vertical);

        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            mousePosition = UtilsClass.GetMouseWorldPosition();

            aimDirection = (mousePosition - transform.position).normalized;

            directionOfRotation = new(aimDirection.x, aimDirection.y);
        }

        if (directionOfRotation != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, directionOfRotation);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
