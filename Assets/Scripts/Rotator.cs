using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationValue;
    public float rotationSpeed;

    public void Update()
    {
        rotationValue += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, rotationValue, 0f);
    }
}
