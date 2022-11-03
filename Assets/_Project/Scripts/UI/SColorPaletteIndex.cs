using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NewPaletteIndex", menuName = "Scriptables/Color Palette Index")]
public class SColorPaletteIndex : ScriptableObject
{
    [TableList]
    public SColorPalette[] palettes;
}