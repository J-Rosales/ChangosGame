using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lobby : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnMarkers;
    public InputActionAsset actionAsset;

    public PlayerInputManager manager;

    public void Start()
    {
        manager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput obj)
    {
        obj.gameObject.transform.position = spawnMarkers[0].transform.position;
    }
}
