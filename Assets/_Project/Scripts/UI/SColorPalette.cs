using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NewPalette", menuName = "Scriptables/Color Palette")]
public class SColorPalette : ScriptableObject
{
    public Color primary;
    public Color secondary;
    public Color highlight;
    public Color border;
}
