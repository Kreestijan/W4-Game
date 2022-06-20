using FishNet.Object;
using UnityEngine;

public sealed class PawnMovement : NetworkBehaviour
{
    private PawnInput _input;

    [SerializeField] private float speed;
    [SerializeField] private float turboMultiplier;

    private Rigidbody2D _playerBody;

    private Vector3 _velocity;
    
    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        _input = GetComponent<PawnInput>();

        _playerBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (!IsOwner) return;

        if (Application.platform == RuntimePlatform.Android)
        {
            _velocity = new(_input.horizontal * speed, _input.vertical * speed, 0.0f);

            if(_input.horizontal >= 0.95 || _input.vertical >= 0.95)
            {
                _playerBody.velocity = _velocity * turboMultiplier;
            }
            else
            {
                _playerBody.velocity = _velocity;
            }
        }
        else if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Vector3 desiredVelocity = Vector3.ClampMagnitude(((transform.up * _input.vertical) + (transform.right * _input.horizontal)) * speed, speed);

            _velocity.x = desiredVelocity.x;
            _velocity.y = desiredVelocity.y;
            _velocity.z = 0f;


            if (_input.turbo)
            {
                _playerBody.velocity = _velocity * turboMultiplier;
            }
            else
            {
                _playerBody.velocity = _velocity;
            }
        }
    }


}//class
