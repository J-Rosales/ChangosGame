using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    public CharacterInput input;
    public ItemDetector detector;
    public GameObject grabbed;
    public Transform grabMarker;

    void Start()
    {
        input.OnUsePressed += ToggleGrab;
    }

    void ToggleGrab()
    {
        if(grabbed == null)
        {
            if(detector.focused != null)
            {
                detector.focused.transform.SetParent(transform);
                detector.focused.transform.position = grabMarker.position;
                grabbed = detector.focused.gameObject;
            }
        } else
        {
            grabbed.transform.SetParent(null);
            grabbed.transform.position = new Vector3(grabbed.transform.position.x, grabbed.GetComponent<MeshRenderer>().bounds.extents.y, grabbed.transform.position.z);
            grabbed = null;
        }
    }
}
