using FishNet.Object;

public abstract class View : NetworkBehaviour
{
    public bool Initialized { get; private set; }

    public virtual void Initialize()
    {
        Initialized = true;
    }
}
