using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;

    [SerializeField] Button createLobby;
    [SerializeField] Button quickJoinButton;
    [SerializeField] Button joinCodeButton;
    [SerializeField] TMP_InputField joinCodeInputField;
    [SerializeField] TMP_InputField playerNameInputField;
    [SerializeField] LobbyCreateUI lobbyCreateUI;
    [SerializeField] Transform lobbyContainer;
    [SerializeField] Transform lobbyTamplate;

    void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.LeaveLobby();
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        createLobby.onClick.AddListener(() =>
        {
            lobbyCreateUI.Show();
        });

        quickJoinButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.QuickJoin();
        });

        joinCodeButton.onClick.AddListener(() =>
        {
            KitchenGameLobby.Instance.JoinWithCode(joinCodeInputField.text);
        });

        lobbyTamplate.gameObject.SetActive(false);
    }

    void Start()
    {
        playerNameInputField.text = KitchenGameMultiPlayer.Instance.GetPlayerName();
        playerNameInputField.onValueChanged.AddListener((string newText) =>
        {
            KitchenGameMultiPlayer.Instance.SetPlayerName(newText);
        });

        KitchenGameLobby.Instance.OnLobbyListChanged += KitchenGameLobby_OnLobbyListChanged;
        UpdateLobbyList(new List<Lobby>());
    }

    void KitchenGameLobby_OnLobbyListChanged(object sender, KitchenGameLobby.OnLobbyListChangedEventArgs e)
    {
        UpdateLobbyList(e.lobbyList);
    }

    void UpdateLobbyList(List<Lobby> lobbyList)
    {
        foreach (Transform child in lobbyContainer)
        {
            if (child == lobbyTamplate) continue;
            Destroy(child.gameObject);
        }

        foreach (Lobby lobby in lobbyList)
        {
            Transform lobbyTransform = Instantiate(lobbyTamplate, lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListSingleUI>().SetLobby(lobby);
        }
    }
}
