using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class PlayerInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI playerNameLabel;
    public Image panelBody;
    public Image panelDivisor;
    public Image inputDeviceIconRenderer;
    public Sprite gamepadIconSprite;
    public Sprite keyboardIconSprite;

    void Start()
    {
        
    }

    public void SetPalette(SColorPalette palette)
    {
        panelBody.color = palette.primary;
        panelDivisor.color = palette.border;
    }
}
