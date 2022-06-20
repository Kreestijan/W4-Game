using UnityEngine;
using UnityEngine.UI;

public sealed class MainView : View
{

    [SerializeField] private Text healthText;
    [SerializeField] private Text playerCoordinates;

    private void Update()
    {
        if (!Initialized) return;

        BRPlayer brplayer = BRPlayer.Instance;

        if (brplayer == null || brplayer.controlledPawn == null) return;

        switch (brplayer.controlledPawn.health)
        {
            case <= 0.0f:
                healthText.color = Color.red;
                healthText.text = "You have perished!";
                break;
            case <= 30.0f:
                healthText.color = Color.red;
                healthText.text = $"Health {brplayer.controlledPawn.health:F2}";
                break;
            case <= 70.0f:
                healthText.color = Color.yellow;
                healthText.text = $"Health {brplayer.controlledPawn.health:F2}";
                break;
            case <= 100.0f:
                healthText.color = Color.green;
                healthText.text = $"Health {brplayer.controlledPawn.health:F2}";
                break;

        }

        playerCoordinates.text = $"X:{brplayer.controlledPawn.transform.position.x:F2} Y:{brplayer.controlledPawn.transform.position.y:F2}";

    }
    
}//class
