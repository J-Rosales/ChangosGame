using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Collider focused;
    public List<Collider> detected;
    public List<Collision> interactable;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            detected.Add(other);
            UpdateFocused();
        }

        else if(other.gameObject.tag == "Container" || other.gameObject.tag == "Workstation")
        {
            detected.Add(other);
        }
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
