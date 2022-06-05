using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using FishNet.Object;

public class PawnAim : NetworkBehaviour
{

    private Vector2 directionOfRotation;
    private Vector3 mousePosition;
    private Vector3 aimDirection;

    private float rotationSpeed = 900f;


    private void Update()
    {
        if(!IsOwner) return;
        

        mousePosition = UtilsClass.GetMouseWorldPosition();

        aimDirection = (mousePosition - transform.position).normalized;

        directionOfRotation = new(aimDirection.x, aimDirection.y);

        if (directionOfRotation != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, directionOfRotation);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
