using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMultiPlayerUI : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.OnMultiplayerGamePaused += GameManager_OnMultiplayerGamePaused;
        GameManager.Instance.OnMultiplayerGameUnpaused += GameManager_OnMultiplayerGameUnpaused;

        Hide();
    }

    void GameManager_OnMultiplayerGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    void GameManager_OnMultiplayerGamePaused(object sender, System.EventArgs e)
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
}
