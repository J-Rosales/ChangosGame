using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workstation : MonoBehaviour
{
    public inputMaterial requiredObject;
    public GameObject outputObject;
    public CharacterInput input;

    public String inputRequired;

    private bool justspawned;

    public void Update()
    {
            input = GameObject.FindGameObjectWithTag("Player")?.GetComponent<CharacterInput>();

        if(input != null)
            input.OnUsePressed += ForgeItemCheck;
    }

    private void ForgeItemCheck()
    {
        if(input.gameObject.GetComponentInChildren<ItemDetector>().detected.Contains(GetComponent<Collider>()) && input.gameObject.GetComponentInChildren<ItemGrabber>().grabbed?.GetComponent<inputMaterial>().inputID == inputRequired && justspawned == false)
        {
            Destroy(input.gameObject.GetComponentInChildren<ItemGrabber>().grabbed);
            input.gameObject.GetComponentInChildren<ItemDetector>().detected.Clear();
            GameObject output = Instantiate(outputObject, input.gameObject.GetComponentInChildren<ItemGrabber>().grabMarker.transform);
            input.gameObject.GetComponentInChildren<ItemGrabber>().grabbed = output;
            input.gameObject.GetComponentInChildren<ItemDetector>().focused = output.GetComponent<Collider>();
            justspawned = true;
        }
    }

    private void LateUpdate()
    {
        justspawned = false;
    }
}
