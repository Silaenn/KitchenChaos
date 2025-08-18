using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectedPlayer : MonoBehaviour
{
    [SerializeField] int playerIndex;
    [SerializeField] GameObject readyGameObject;
    [SerializeField] PlayerVisual playerVisual;
    [SerializeField] Button kickButton;

    void Awake()
    {
        kickButton.onClick.AddListener(() =>
        {
            PlayerData playerData = KitchenGameMultiPlayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);

            KitchenGameMultiPlayer.Instance.KickPlayer(playerData.clientId);
        });
    }
    void Start()
    {
        KitchenGameMultiPlayer.Instance.OnPlayerDataNetworkListChanged += KitchenGameMultiPlayer_OnPlayerDataNetworkListChanged;
        CharacterSelectReady.Instance.OnReadyChanged += CharacterSelectReady_OnReadyChanged;

        kickButton.gameObject.SetActive(NetworkManager.Singleton.IsServer);

        UpdatePlayer();
    }

    void CharacterSelectReady_OnReadyChanged(object sender, EventArgs e)
    {
        UpdatePlayer();
    }

    void KitchenGameMultiPlayer_OnPlayerDataNetworkListChanged(object sender, System.EventArgs e)
    {
        UpdatePlayer();
    }

    void UpdatePlayer()
    {
        if (KitchenGameMultiPlayer.Instance.IsPlayerIndexConnected(playerIndex))
        {
            Show();

            PlayerData playerData = KitchenGameMultiPlayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);

            readyGameObject.SetActive(CharacterSelectReady.Instance.IsPlayerReady(playerData.clientId));

            playerVisual.SetPlayerColor(KitchenGameMultiPlayer.Instance.GetPlayerColor(playerData.colorId));
        }
        else
        {
            Hide();
        }
    }

    void Show()
    {
        gameObject.SetActive(true);
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }
}
