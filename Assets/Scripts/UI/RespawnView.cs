using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class RespawnView : View
{
    [SerializeField] private Button respawnButton;

    public override void Initialize()
    {
        respawnButton.onClick.AddListener(() =>
        {
            BRPlayer.Instance.Respawn();
        });

        base.Initialize();
    }
}
