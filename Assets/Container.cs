using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public GameObject storedObject;
    public CharacterInput input;
    private bool justspawned;

    public void Update()
    {
            input = GameObject.FindGameObjectWithTag("Player")?.GetComponent<CharacterInput>();

        if(input != null)
            input.OnUsePressed += GiveItemCheck;
    }

    private void GiveItemCheck()
    {
        if (input.gameObject.GetComponentInChildren<ItemDetector>().detected.Contains(GetComponent<Collider>()) && justspawned == false)
        {
            GameObject pickup = Instantiate(storedObject, input.gameObject.GetComponentInChildren<ItemGrabber>().grabMarker.transform);
            input.gameObject.GetComponentInChildren<ItemGrabber>().grabbed = pickup;
            input.gameObject.GetComponentInChildren<ItemDetector>().focused = pickup.GetComponent<Collider>();
            justspawned = true;
        }

    }

    private void LateUpdate()
    {
        justspawned = false;
    }
}
