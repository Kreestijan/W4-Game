using UnityEngine;
using UnityEngine.UI;

public sealed class MainView : View
{

    [SerializeField] private Text healthText;

    private void Update()
    {
        if (!Initialized) return;

        BRPlayer brplayer = BRPlayer.Instance;

        if (brplayer == null || brplayer.controlledPawn == null) return;

        healthText.text = $"Health {brplayer.controlledPawn.health}";

    }


}//class
