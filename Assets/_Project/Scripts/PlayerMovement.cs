using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class PlayerMovement : MonoBehaviour
{
    public float baseMoveSpeed;
    public float rotateSpeed;
    public Vector2 turnSpeedMultiplierRange;
    
    [Space]
    [ReadOnly]
    public Vector3 finalMoveVector;
    
    [ReadOnly]
    public bool isTurningInstant;
    
    [Space]
    public CharacterInput input;
    public Rigidbody myRigidbody;


    void Start()
    {
        input.OnLeftModifierPressed += () => isTurningInstant = true;
        input.OnLeftModifierReleased += () => isTurningInstant = false;
    }

    public void FixedUpdate()
    {
        float turnMultiplier = isTurningInstant ? 1f : CalculateTurnMultiplier();
        finalMoveVector = input.moveVector * baseMoveSpeed * turnMultiplier;
        myRigidbody.MovePosition(myRigidbody.position + finalMoveVector  * Time.fixedDeltaTime);
        transform.rotation = isTurningInstant ? input.lastLookRotation : CalculateRotationStep();
    }

    Quaternion CalculateRotationStep()
    {
        return Quaternion.Slerp (transform.rotation, input.lastLookRotation,
                rotateSpeed * Time.deltaTime);
    }

    float CalculateTurnMultiplier()
    {
        return Mathf.Lerp(turnSpeedMultiplierRange.x, turnSpeedMultiplierRange.y,
                1 - (Quaternion.Angle(transform.rotation,
                        input.lastLookRotation) / 180f));
    }
}
