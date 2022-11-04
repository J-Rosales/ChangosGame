using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Item focused;
    public List<Item> detected;
    public List<Item> interactable;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Item placeable))
        {
            detected.Add(placeable);
            UpdateFocused();
        }
    }

    public void UpdateFocused()
    {
        focused = detected.Count > 0 ? detected[0] : null;
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Item placeable))
        {
            detected.Remove(placeable);
            UpdateFocused();
        }
    }
}
