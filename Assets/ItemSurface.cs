using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemSurface : Item
{
    public Transform[] itemAnchors;
    public List<Item> heldItems;
    public Item lastAdded;

    void Start()
    {
        heldItems = new List<Item>(itemAnchors.Length);
    }

    internal void Place(Placeable item)
    {
        for (int i = 0; i < heldItems.Count; i++)
        {
            if (heldItems[i] == null)
            {
                item.Place(this, itemAnchors[i]);
                heldItems[i] = item;
                lastAdded = item;
                break;
            }
        }
    }

    public Placeable RemoveLatest()
    {
        if(lastAdded == null)
            return null;

        Placeable toRemove = lastAdded as Placeable;
        heldItems.Remove(lastAdded);
        lastAdded = null;
        return toRemove;
    }
}
