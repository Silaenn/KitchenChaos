using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    const string PLAYER_PREFS_BINDINGS = "InputBindings";
    public static GameInput Instance { get; set; }
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    public enum Binding
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        InteractALternate,
        Pause,
        Gamepad_Interact,
        Gamepad_InteractAlternate,
        Gamepad_Pause

    }
    PlayerInput playerInput;
    void Awake()
    {
        Instance = this;
        playerInput = new PlayerInput();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
        {
            playerInput.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));
        }

        playerInput.Player.Enable();

        playerInput.Player.Interact.performed += Interact_performed;
        playerInput.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInput.Player.Pause.performed += Pause_Performed;
        // ResetBindings();
    }

    void OnDestroy()
    {
        playerInput.Player.Interact.performed -= Interact_performed;
        playerInput.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playerInput.Player.Pause.performed -= Pause_Performed;

        playerInput.Dispose();
    }

    void Pause_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.Move_Up:
                return playerInput.Player.Move.bindings[1].ToDisplayString();
            case Binding.Move_Down:
                return playerInput.Player.Move.bindings[2].ToDisplayString();
            case Binding.Move_Left:
                return playerInput.Player.Move.bindings[3].ToDisplayString();
            case Binding.Move_Right:
                return playerInput.Player.Move.bindings[4].ToDisplayString();
            case Binding.Interact:
                return playerInput.Player.Interact.bindings[0].ToDisplayString();
            case Binding.InteractALternate:
                return playerInput.Player.InteractAlternate.bindings[0].ToDisplayString();
            case Binding.Pause:
                return playerInput.Player.Pause.bindings[0].ToDisplayString();
            case Binding.Gamepad_Interact:
                return playerInput.Player.Interact.bindings[1].ToDisplayString();
            case Binding.Gamepad_InteractAlternate:
                return playerInput.Player.InteractAlternate.bindings[1].ToDisplayString();
            case Binding.Gamepad_Pause:
                return playerInput.Player.Pause.bindings[1].ToDisplayString();
        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound)
    {
        playerInput.Player.Disable();

        InputAction inputAction;
        int bindingIndex;
        switch (binding)
        {
            default:
            case Binding.Move_Up:
                inputAction = playerInput.Player.Move;
                bindingIndex = 1;
                break;
            case Binding.Move_Down:
                inputAction = playerInput.Player.Move;
                bindingIndex = 2;
                break;
            case Binding.Move_Left:
                inputAction = playerInput.Player.Move;
                bindingIndex = 3;
                break;
            case Binding.Move_Right:
                inputAction = playerInput.Player.Move;
                bindingIndex = 4;
                break;
            case Binding.Interact:
                inputAction = playerInput.Player.Interact;
                bindingIndex = 0;
                break;
            case Binding.InteractALternate:
                inputAction = playerInput.Player.InteractAlternate;
                bindingIndex = 0;
                break;
            case Binding.Pause:
                inputAction = playerInput.Player.Pause;
                bindingIndex = 0;
                break;
            case Binding.Gamepad_Interact:
                inputAction = playerInput.Player.Interact;
                bindingIndex = 1;
                break;
            case Binding.Gamepad_InteractAlternate:
                inputAction = playerInput.Player.InteractAlternate;
                bindingIndex = 1;
                break;
            case Binding.Gamepad_Pause:
                inputAction = playerInput.Player.Pause;
                bindingIndex = 1;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex).OnComplete(callback =>
        {
            callback.Dispose();
            playerInput.Player.Enable();
            onActionRebound();

            PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, playerInput.SaveBindingOverridesAsJson());
            PlayerPrefs.Save();
        }).Start();
    }

    public void ResetBindings()
    {
        PlayerPrefs.DeleteKey(PLAYER_PREFS_BINDINGS);
        PlayerPrefs.Save();

        playerInput.Dispose();
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }


   
}
