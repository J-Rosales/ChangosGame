using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    public Canvas levelCanvas;
    public TextMeshProUGUI winLabel;

    void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
            SceneManager.LoadScene("Level");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerInput player))
        {
            levelCanvas.gameObject.SetActive(true);
            winLabel.SetText($"{player.gameObject.name}\nWins!");
            foreach(PlayerMovement p in FindObjectsOfType<PlayerMovement>())
            {
                p.enabled = false;
            }
        }
    }
}
