using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; set; }

    [SerializeField] Button soundEffectsButton;
    [SerializeField] Button musicButton;
    [SerializeField] Button closeButton;
    [SerializeField] TextMeshProUGUI soundEffectsText;
    [SerializeField] TextMeshProUGUI musicText;

    void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    void Start()
    {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        Hide();
        UpdateVisual();
    }

    void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    void UpdateVisual()
    {
        if (SoundManager.Instance != null)
            soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);

        if (MusicManager.Instance != null)
            musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

}
