using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{

    void Start()
    {
        KitchenGameMultiPlayer.Instance.OnTryingToJoinGame += KitchenGameMultiPlayer_OnTryingToJoinGame;
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame += KitchenGameMultiPlayer_OnFailedToJoinGame;
        Hide();
    }

    void KitchenGameMultiPlayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        Hide();
    }

    void KitchenGameMultiPlayer_OnTryingToJoinGame(object sender, EventArgs e)
    {
        Show();
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
        KitchenGameMultiPlayer.Instance.OnTryingToJoinGame -= KitchenGameMultiPlayer_OnTryingToJoinGame;
        KitchenGameMultiPlayer.Instance.OnFailedToJoinGame -= KitchenGameMultiPlayer_OnFailedToJoinGame;
    }
}
