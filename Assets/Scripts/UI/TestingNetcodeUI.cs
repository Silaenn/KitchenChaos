using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] Button startHostButton;
    [SerializeField] Button startClientButton;

    void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            Debug.Log("HOST");
            KitchenGameMultiPlayer.Instance.StartHost();
            Hide();
        });

        startClientButton.onClick.AddListener(() =>
        {
            Debug.Log("CLIENT");
            KitchenGameMultiPlayer.Instance.StartClient();
            Hide();
        });
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
