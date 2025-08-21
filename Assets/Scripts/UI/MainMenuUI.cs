using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button playSingleButton;
    [SerializeField] Button playMultipleButton;
    [SerializeField] Button quitButton;

    void Awake()
    {
        playMultipleButton.onClick.AddListener(() =>
        {
            KitchenGameMultiPlayer.playMultiplayer = true;
            Loader.Load(Loader.Scene.LobbyScene);
        });
        
        playSingleButton.onClick.AddListener(() =>
        {
            KitchenGameMultiPlayer.playMultiplayer = false;
            Loader.Load(Loader.Scene.LobbyScene);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }

}
