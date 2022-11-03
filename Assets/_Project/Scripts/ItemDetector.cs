using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Placeable focused;
    public List<Placeable> detected;
    public List<Placeable> interactable;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Placeable placeable))
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
        if(other.TryGetComponent(out Placeable placeable))
        {
            detected.Remove(placeable);
            UpdateFocused();
        }
    }
}
