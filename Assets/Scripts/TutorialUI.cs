using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keyMoveUpText;
    [SerializeField] TextMeshProUGUI keyMoveDownText;
    [SerializeField] TextMeshProUGUI keyMoveLeftText;
    [SerializeField] TextMeshProUGUI keyMoveRightText;
    [SerializeField] TextMeshProUGUI keyMoveInteractText;
    [SerializeField] TextMeshProUGUI keyMoveInteractAlternateText;
    [SerializeField] TextMeshProUGUI keyMovePauseText;
    [SerializeField] TextMeshProUGUI keyMoveGamepadInteractText;
    [SerializeField] TextMeshProUGUI keyMoveGamepadInteractAlternateText;
    [SerializeField] TextMeshProUGUI keyMoveGamepadPauseText;

    void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        UpdateVisual();

        if (GameManager.Instance.IsCountdownToStartActive() || GameManager.Instance.IsGamePlaying() || GameManager.Instance.isGameOver())
        {
            Hide();
        }
        else
        {
            Show();
        }
        
    }

    void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }
    void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        keyMoveInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        keyMoveInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractALternate);
        keyMovePauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        keyMoveGamepadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        keyMoveGamepadInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        keyMoveGamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
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
