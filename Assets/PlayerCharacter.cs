using System;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public CharacterInput playerInput;
    public ItemHolder itemHolder;
    public ItemDetector itemDetector;

    void Start()
    {
        playerInput.OnGrabPressed += ItemGrabCheck;
        playerInput.OnUsePressed += ItemUseCheck;
    }

    void ItemGrabCheck()
    {
        if(itemHolder.heldItem != null)
        {
            itemHolder.heldItem.Place(itemHolder.holdAnchor.position, null);
            itemHolder.heldItem = null;
        }
        else if(itemDetector.focused != null)
        {
            Give(itemDetector.focused);
            itemDetector.detected.Clear();
            itemDetector.UpdateFocused();
        }
    }

    void ItemUseCheck()
    {
        if(itemDetector.focused == null)
            return;

        itemDetector.focused.TryRotate(new Vector3(0f, 90f, 0f));
    }

    public void Give(Placeable item)
    {
        itemHolder.TryAdd(item);
    }
}
