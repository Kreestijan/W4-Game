using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplayer : NetworkBehaviour
{
    [SerializeField] private Text _text;

    public override void OnStartClient()
    {
        base.OnStartClient();
        PlayerNameTracker.OnNameChange += PlayerNameTracker_OnNameChange;
        
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        PlayerNameTracker.OnNameChange -= PlayerNameTracker_OnNameChange;
    }

    public override void OnOwnershipClient(NetworkConnection prevOwner)
    {
        base.OnOwnershipClient(prevOwner);
        SetName();
    }

    private void PlayerNameTracker_OnNameChange(NetworkConnection arg1, string arg2)
    {
        if (arg1 != base.Owner)
            return;
        
        SetName();
    }

    //Sets Text to the name for this object's owner
    private void SetName()
    {
        string result = null;
        //Owner does not exist
        if (base.Owner.IsValid)
            result = PlayerNameTracker.GetPlayerName(base.Owner);

        if (string.IsNullOrEmpty(result))
            result = $"Guest{Random.Range(0, 999)}";

        _text.text = result;
    }


}//class

