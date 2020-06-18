using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRendererAnchor : MonoBehaviour
{
    Vector3 worldAnchor;
    // Start is called before the first frame update
    void Start()
    {
        //worldAnchor = GetComponentInChildren<WorldRenderer>().GetWorldSize();
        transform.position = new Vector3(0, 0, 0);
        //Debug.Log(worldAnchor);
        //Debug.Log(transform.position);
        //Debug.Log(GetComponentInChildren<WorldGeneration>().GetWorldSize());
        //Debug.Log(GetComponentInChildren<WorldGeneration>().GetWorldHeight());
    }
}
