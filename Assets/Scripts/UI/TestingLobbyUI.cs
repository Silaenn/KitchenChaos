using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingLobbyUI : MonoBehaviour
{
    [SerializeField] Button createGameButton;
    [SerializeField] Button joinGameButton;

    void Awake()
    {
        createGameButton.onClick.AddListener(() =>
        {
            KitchenGameMultiPlayer.Instance.StartHost();
            Loader.LoadNetwork(Loader.Scene.CharacterSelectScene);
        });

        joinGameButton.onClick.AddListener(() =>
        {
            KitchenGameMultiPlayer.Instance.StartClient();
        });
    }
}
