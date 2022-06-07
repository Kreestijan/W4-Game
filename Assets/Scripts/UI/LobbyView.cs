using FishNet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class LobbyView : MonoBehaviour
{
    [SerializeField] private Button toggleReady;

    [SerializeField] private Text toggleReadyText;
    
    [SerializeField] private Button startGame;


    private bool _initialized;
    public void Initialize()
    {
        toggleReady.onClick.AddListener(() => BRPlayer.Instance.ServerSetIsReady(!BRPlayer.Instance.isReady));

        if (InstanceFinder.IsHost)
        {
            startGame.onClick.AddListener(() => GameManager.Instance.StartGame());
            startGame.gameObject.SetActive(true);
        }
        else startGame.gameObject.SetActive(false);

        _initialized = true;
    }

    private void Update()
    {
        if (!_initialized) return;

        toggleReadyText.color = BRPlayer.Instance.isReady ? Color.green : Color.red;

        startGame.interactable = GameManager.Instance.canStart;
    }
}
