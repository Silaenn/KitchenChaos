using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualGameObject;
    void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    void Show()
    {
        visualGameObject.SetActive(true);
    }

    void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
