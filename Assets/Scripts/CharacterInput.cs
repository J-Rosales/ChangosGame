using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    public event Action OnUsePressed;
    public InputActionAsset actionAsset;
    public Vector3 moveVector;
    public Vector3 rotateVector;
    
    InputActionMap map;

    void Start()
    {
        map = actionAsset.FindActionMap("Player");
        map.Enable();

        map["Move"].performed += OnMove;
        map["Move"].canceled += OnMove;

        map["Rotate"].performed += OnRotate;
        map["Rotate"].canceled += OnRotate;

        map["Use"].performed += OnUse;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        moveVector = new Vector3(move.x, 0, move.y);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        Vector2 rotate = context.ReadValue<Vector2>();
        rotateVector = new Vector3(0f, rotate.x, 0f);
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton() && context.performed)
        {
            OnUsePressed?.Invoke();
        }
    }
}
