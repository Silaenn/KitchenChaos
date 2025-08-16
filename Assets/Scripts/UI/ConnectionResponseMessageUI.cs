using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionResponseMessageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] Button closeButton;

    void Awake()
    {
        closeButton.onClick.AddListener(Hide);
    }

    void Start()
    {
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame += KitchenGameMultiPlayer_OnFailedToJoinGame;

        Hide();
    }

    void KitchenGameMultiPlayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        Show();

        messageText.text = NetworkManager.Singleton.DisconnectReason;

        if (messageText.text == "")
        {
            messageText.text = "Failed to connect";
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

    void OnDestroy()
    {
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame -= KitchenGameMultiPlayer_OnFailedToJoinGame;
    }
}
