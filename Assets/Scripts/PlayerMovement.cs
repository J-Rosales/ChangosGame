using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody myRigidbody;
    public Vector3 moveVector;

    public void OnMove(InputValue value)
    {
        Vector2 move = value.Get<Vector2>();
        moveVector = new Vector3(move.x, 0, move.y);
    }

    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }
}
