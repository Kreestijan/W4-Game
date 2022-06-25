using FishNet.Object;
using FishNet.Object.Synchronizing;
using System.Collections;
using UnityEngine;

public sealed class Pawn : NetworkBehaviour
{
    [SyncVar] public BRPlayer controllingPlayer;

    [SyncVar] public float health;

    [SerializeField] private GameObject deathAnimationReference;

    private AudioSource soundEffect;

    private PawnInput _input;
    private PawnMovement _movement;
    private Collider2D _collider;

    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        soundEffect = GetComponent<AudioSource>();

        _input = GetComponent<PawnInput>();
        _movement = GetComponent<PawnMovement>();
        _collider = GetComponent<Collider2D>();

    }
    public void TakeDamage(float amount)
    {
        if (!IsSpawned) return;

        health -= amount;
        
        if(health <= 0.0f)
        {
            _collider.enabled = false;

            GameObject deathAnimation = Instantiate(deathAnimationReference);
            deathAnimation.transform.position = this.transform.position;
            Spawn(deathAnimation);

            Despawn();

            GameManager.Instance.alivePlayers--;

            Destroy(deathAnimation, 1.5f);

            controllingPlayer.TargetPawnKilled(Owner);
        }
    }

    public void PlayAudio(string filename, ulong delay)
    {
        soundEffect.clip = Resources.Load<AudioClip>("Audioclips/" + filename);
        soundEffect.Play(delay);
    }

    [Server]

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsSpawned && collision.gameObject.CompareTag("Pawn"))
        {
            gameObject.GetComponent<Pawn>().TakeDamage(100.0f);
        }
    }

}//class
