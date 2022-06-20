using FishNet.Object;
using UnityEngine;

public sealed class MultiplayerCameraFollow : NetworkBehaviour
{
    private Vector3 tempPos;

    private Transform myCamera;

    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        myCamera = GameObject.FindWithTag("MainCamera").transform;
    }
    private void Update()
    {
        if (!IsOwner) return;

        tempPos = myCamera.transform.position;

        if (myCamera.transform.position != null)
        {
            tempPos.x = transform.position.x;
            tempPos.y = transform.position.y;
        }

        myCamera.transform.position = tempPos;
    }










}






    /*private Transform playerTransform;

    private GameObject[] pawns;

    private Vector3 tempPos;

    void Update()
    {
        pawns = GameObject.FindGameObjectsWithTag("Pawn");
        
        foreach(GameObject pawn in pawns)
        {
            if (pawn.GetComponent<Pawn>().Owner.ClientId == Owner.ClientId)
            {
                playerTransform = pawn.transform;
            }
        }
        
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        tempPos = transform.position;

        if (playerTransform != null)
        {
            tempPos.x = playerTransform.position.x;
            tempPos.y = playerTransform.position.y;
        }

        transform.position = tempPos;
    }
}*/
