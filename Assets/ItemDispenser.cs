using UnityEngine;
using Sirenix.OdinInspector;

public class ItemDispenser : MonoBehaviour
{
    [PreviewField]
    public GameObject itemPrefab;

    public void Use(PlayerCharacter user)
    {
        user.Give(Generate() as Placeable);
    }

    public Item Generate()
    {
        return Instantiate(itemPrefab).GetComponent<Item>();
    }
}
