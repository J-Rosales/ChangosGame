using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Collider focused;
    public List<Collider> detected;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PickupCube")
            detected.Add(other);

        UpdateFocused();
    }

    void UpdateFocused()
    {
        focused = detected.Count > 0 ? detected[0] : null;
    }

    public void OnTriggerExit(Collider other)
    {
        if(detected.Contains(other))
        {
            detected.Remove(other);
            UpdateFocused();
        }
    }
}
