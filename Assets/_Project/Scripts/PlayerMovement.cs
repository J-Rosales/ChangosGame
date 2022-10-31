using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    [Space]
    public CharacterInput input;
    public MeshRenderer[] renderers;
    public Rigidbody myRigidbody;

    void Start()
    {
        RandomizeMaterial();
    }

    private void RandomizeMaterial()
    {
        Color color = Color.HSVToRGB(UnityEngine.Random.Range(0f, 1f), 1f, 1f);
        Material newMaterial = new Material(renderers[0].material);
        newMaterial.name = "_PlayerMaterial";
        newMaterial.color = color;
        foreach (MeshRenderer mesh in renderers)
            mesh.materials = new Material[] {newMaterial};
    }

    public void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(
                input.rotateVector * rotateSpeed * Time.fixedDeltaTime);
        
        myRigidbody.MovePosition(myRigidbody.position + input.moveVector * moveSpeed * Time.fixedDeltaTime);
        myRigidbody.MoveRotation(myRigidbody.rotation * deltaRotation);
        transform.rotation = Quaternion.Slerp (transform.rotation, input.lastLookRotation, Time.deltaTime * 20f);
    }
}
