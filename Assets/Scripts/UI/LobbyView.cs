using FishNet;
using UnityEngine;
using UnityEngine.UI;

public sealed class LobbyView : View
{
    [SerializeField] private Button toggleReady;

    [SerializeField] private Text toggleReadyText;
    
    [SerializeField] private Button startGame;

    [SerializeField] private Text startGameText;

    public override void Initialize()
    {
        toggleReady.onClick.AddListener(() => BRPlayer.Instance.ServerSetIsReady(!BRPlayer.Instance.isReady));

        if (InstanceFinder.IsHost)
        {
            startGame.onClick.AddListener(() => GameManager.Instance.StartGame());
            startGame.gameObject.SetActive(true);
        }
        else startGame.gameObject.SetActive(false);

        base.Initialize();

    }

    private void Update()
    {
        if (!Initialized) return;

        toggleReadyText.color = BRPlayer.Instance.isReady ? Color.green : Color.red;

        startGame.interactable = GameManager.Instance.canStart;

        startGameText.color = startGame.interactable ? Color.white : Color.gray;
        
    }
}
