using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : Item
{
    public Collider holdCollider;
    public bool isHeldByPlayer;

    public void PlaceManual(Vector3 position, Transform parent)
    {
        transform.SetParent(parent);
        transform.position = position;
    }

    public void Place(Vector3 position, Transform parent)
    {
        transform.SetParent(parent);
        transform.position = new Vector3(Mathf.Round(position.x), 1f, Mathf.Round(position.z));
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        isHeldByPlayer = false;
    }

    public void PlaceOnGrid()
    {
        
    }

    public void Place(ItemSurface surface, Transform itemAnchor)
    {
        transform.SetParent(surface.transform);
        transform.position = itemAnchor.position - surfaceAnchor.localPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        isHeldByPlayer = false;
    }
}
