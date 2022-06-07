using FishNet.Object;
using UnityEngine;

public sealed class PawnMovement : NetworkBehaviour
{
    private PawnInput _input;

    [SerializeField] private float speed;
    [SerializeField] private float turboSpeed;

    private CharacterController _characterController;

    private Vector3 _velocity;
    
    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        _input = GetComponent<PawnInput>();

        _characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        if (!IsOwner) return;

        Vector3 desiredVelocity = Vector3.ClampMagnitude(((transform.up * _input.vertical) + (transform.right * _input.horizontal)) * speed, speed);
        
        _velocity.x = desiredVelocity.x;
        _velocity.y = desiredVelocity.y;
        _velocity.z = 0f;

        if (_input.turbo)
        {
            _velocity.x *= turboSpeed;
            //_velocity.y *= turboSpeed;
        }

        _characterController.Move(_velocity * Time.deltaTime);
    }

}//class
