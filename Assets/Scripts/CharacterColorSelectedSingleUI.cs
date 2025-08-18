using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterColorSelectedSingleUI : MonoBehaviour
{
    [SerializeField] int colorId;
    [SerializeField] Image image;
    [SerializeField] GameObject selectedGameObject;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            KitchenGameMultiPlayer.Instance.ChangePlayerColor(colorId);
        });
    }

    void Start()
    {
        KitchenGameMultiPlayer.Instance.OnPlayerDataNetworkListChanged += KitchenGameMultiPlayer_OnPlayerDataNetworkListChanged;
        image.color = KitchenGameMultiPlayer.Instance.GetPlayerColor(colorId);
        UpdateIsSelected();
    }

    private void KitchenGameMultiPlayer_OnPlayerDataNetworkListChanged(object sender, EventArgs e)
    {
        UpdateIsSelected();
    }

    void UpdateIsSelected()
    {
        if (KitchenGameMultiPlayer.Instance.GetPlayerData().colorId == colorId)
        {
            selectedGameObject.SetActive(true);
        }
        else
        {
            selectedGameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        KitchenGameMultiPlayer.Instance.OnPlayerDataNetworkListChanged -= KitchenGameMultiPlayer_OnPlayerDataNetworkListChanged;
    }
}
