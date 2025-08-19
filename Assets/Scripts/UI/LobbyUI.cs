using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
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
    }

    void Start()
    {
        playerNameInputField.text = KitchenGameMultiPlayer.Instance.GetPlayerName();
        playerNameInputField.onValueChanged.AddListener((string newText) =>
        {
            KitchenGameMultiPlayer.Instance.SetPlayerName(newText);
        });
    }
}
