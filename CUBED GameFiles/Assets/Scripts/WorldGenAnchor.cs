using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenAnchor : MonoBehaviour
{
    Vector3 worldAnchor;
    // Start is called before the first frame update
    void Start()
    {
        worldAnchor = new Vector3(((GetComponentInChildren<WorldGeneration>().GetWorldSize() / 2) * -1) + 0.5f, (GetComponentInChildren<WorldGeneration>().GetWorldHeight() * -1) + 0.5f);
        transform.position = worldAnchor;
        //Debug.Log(worldAnchor);
        //Debug.Log(transform.position);
        //Debug.Log(GetComponentInChildren<WorldGeneration>().GetWorldSize());
        //Debug.Log(GetComponentInChildren<WorldGeneration>().GetWorldHeight());
    }
}
