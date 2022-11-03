using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGridManager : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.66f);
        for (int z = -10; z < 10; z++)
        {
            for (int x = -10; x < 10; x++)
            {
                Gizmos.DrawWireCube(new Vector3(x, 0f, z), new Vector3(1f, 0.05f, 1f));
            }    
        }
    }
}
