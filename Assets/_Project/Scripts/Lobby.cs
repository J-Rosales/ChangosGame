using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lobby : MonoBehaviour
{
    public Transform[] spawnMarkers;

    [ReadOnly]
    public List<PlayerElements> livePlayers;

    [Space]
    public PlayerInputManager manager;
    public InputActionAsset actionAsset;
    public SColorPaletteIndex playerPaletteIndex;
    public Canvas levelCanvas;
    public RectTransform playerInfoPanelArea;
    [Space]
    public GameObject playerPrefab;
    public GameObject playerInfoPanelPrefab;

    public void Start()
    {
        manager.onPlayerJoined += OnPlayerJoined;
        manager.onPlayerLeft += OnPlayerLeft;
    }

    void OnPlayerJoined(PlayerInput player)
    {
        player.gameObject.transform.position = spawnMarkers[0].transform.position;
        PlayerInfoPanel infoPanel = Instantiate(playerInfoPanelPrefab,
                playerInfoPanelArea).GetComponent<PlayerInfoPanel>();
        livePlayers.Add(new PlayerElements(player, infoPanel, GetUniquePalette()));
    }

    void OnPlayerLeft(PlayerInput player)
    {
        PlayerElements toDelete = null;
        foreach (PlayerElements livePlayer in livePlayers)
        {
            if(livePlayer.input == player)
            {
                Destroy(livePlayer.infoPanel.gameObject);
                toDelete = livePlayer;
                break;
            }
        }
        if(toDelete != null)
            livePlayers.Remove(toDelete);
    }

    SColorPalette GetUniquePalette()
    {
        List<SColorPalette> used = new List<SColorPalette>();
        foreach (SColorPalette palette in playerPaletteIndex.palettes)
        {
            //get unused;
        }

        return null;
    }

    [Serializable]
    public class PlayerElements
    {
        public PlayerInput input;
        public PlayerInfoPanel infoPanel;
        public SColorPalette palette;

        public PlayerElements(PlayerInput input, PlayerInfoPanel infoPanel, SColorPalette palette)
        {
            this.input = input;
            this.infoPanel = infoPanel;
            this.palette = palette;
        }
    }
}
