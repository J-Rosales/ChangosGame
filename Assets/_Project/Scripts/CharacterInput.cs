using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    public event Action OnUsePressed;
    public event Action OnGrabPressed;
    public Vector3 moveVector;
    public Vector3 rotateVector;
    public Quaternion lastLookRotation;

    PlayerInput playerInput;

    public void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += OnActionTriggered;
        /*
        Input/Output for Item converter uses scriptable index of items, steal from bonegame
program things falling on to the "floor" (has to be in grid, animate a curve of it flying with
IEnumerator because Animator component is the pee pee poo poo)
Compare IDs
        */
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Move":
                OnMove(context);
                break;
            case "Use":
                OnUse(context);
                break;
            case "Grab":
                OnGrab(context);
                break;
            case "Rotate":
                OnRotate(context);
                break;
            case "Pause":
                OnPause(context);
                break;
            default:
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        moveVector = new Vector3(move.x, 0, move.y);
        if(moveVector != Vector3.zero)
            lastLookRotation = Quaternion.LookRotation(moveVector);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        Vector2 rotate = context.ReadValue<Vector2>();
        rotateVector = new Vector3(0f, rotate.x, 0f);
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton() && context.performed)
            OnUsePressed?.Invoke();
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton() && context.performed)
            OnGrabPressed?.Invoke();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Level");
    }
}
