using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform surfaceAnchor;
    IEnumerator rotationLerp;

    public void Delete()
    {
        Destroy(gameObject);
    }

    public bool TryRotate(Vector3 rotateVector)
    {
        if(rotationLerp != null)
            return false;

        rotationLerp = RotationLerpRoutine(rotateVector);
        StartCoroutine(rotationLerp);
        return true;
    }

    IEnumerator RotationLerpRoutine(Vector3 rotateVector)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(rotateVector);
        float rotateTime = 0.5f;
        float rotateCounter = 0f;

        while(rotateCounter < rotateTime)
        {
            rotateCounter += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotateCounter/rotateTime);
            yield return null;
        }

        transform.rotation = endRotation;
        rotationLerp = null;
    }
}
