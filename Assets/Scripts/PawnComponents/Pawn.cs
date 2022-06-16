using FishNet.Object;
using FishNet.Object.Synchronizing;

public sealed class Pawn : NetworkBehaviour
{
    [SyncVar] public BRPlayer controllingPlayer;

    [SyncVar] public float health;

    public override void OnStartClient()
    {
        base.OnStartClient();
    }

    public void TakeDamage(float amount)
    {
        if (!IsSpawned) return;

        health -= amount;
        
        if(health <= 0.0f)
        {
            controllingPlayer.TargetPawnKilled(Owner);
            Despawn();
            GameManager.Instance.alivePlayers--;
        }
    }


}//class
