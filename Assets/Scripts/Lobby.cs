using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lobby : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnMarker;
    
    void Start()
    {
        Instantiate(playerPrefab, spawnMarker.position, Quaternion.identity, null);
        foreach (InputDevice device in InputSystem.devices)
        {
            Debug.Log(device.name);
        }            
    }

    
}
