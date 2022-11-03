using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Placeable heldItem;
    public Transform holdAnchor;

    public void TryAdd(Placeable item)
    {
       /* if(heldItem != null) SWAPPING
            heldItem.Place(item.transform.position, item.transform.parent);*/

        heldItem = item;
        heldItem.transform.SetParent(transform);
        heldItem.transform.position = holdAnchor.position;
    }

    public void DeleteHeld()
    {
        heldItem.Delete();
    }
}