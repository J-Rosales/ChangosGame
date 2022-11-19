using System;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public CharacterInput playerInput;
    public ItemHolder itemHolder;
    public ItemDetector itemDetector;
    public MeshRenderer[] renderers;

    void Start()
    {
        RandomizeMaterial();
        playerInput.OnGrabPressed += ItemGrabCheck;
        playerInput.OnUsePressed += ItemUseCheck;
    }

    void ItemGrabCheck()
    {
        if(itemHolder.heldItem != null)
        {
            if(itemDetector.focused is ItemSurface surface)
                surface.Place(itemHolder.heldItem);
            else
                itemHolder.heldItem.Place(itemHolder.holdAnchor.position, null);
            itemHolder.heldItem = null;
        }
        else if(itemDetector.focused != null)
        {
            if(itemDetector.focused is Placeable placeable
                    && !placeable.isHeldByPlayer)
            {
                Give(placeable);
                itemDetector.detected.Clear();
                itemDetector.UpdateFocused();
            }
            else if(itemDetector.focused is ItemSurface surface && surface.lastAdded != null)
            {
                Give(surface.RemoveLatest());
            }
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
        item.isHeldByPlayer = true;
    }

    void RandomizeMaterial()
    {
        Color color = Color.HSVToRGB(UnityEngine.Random.Range(0f, 1f), 1f, 1f);
        Material newMaterial = new Material(renderers[0].material);
        newMaterial.name = "_PlayerMaterial";
        newMaterial.color = color;
        foreach (MeshRenderer mesh in renderers)
            mesh.materials = new Material[] {newMaterial};
    }
}
