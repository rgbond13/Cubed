using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject[] blocks;
    public Transform startLoc;
    public GameObject[] world;
    public int worldHeight;
    public int worldSize;
    GameObject tile;
    Transform loc;
    private int tileType = 0;
    private float xLoc = 0f;
    private float yLoc = 0f;
    public float yClip;
    public float mineHeight;
    public float underWorldHeight;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        transform.position = new Vector3(-(worldSize/2), worldHeight);
        StartCoroutine("WorldGenerator");
        Debug.Log("Continuing Routine");
    }


    IEnumerator WorldGenerator()
    {
        while (transform.position.x <= worldSize/2)
        {
            while (transform.position.y <= yClip)
            {
                // Tile Picker
                if (yLoc <= underWorldHeight)
                {
                    tileType = 2;
                    //Debug.Log("Underworld");
                }
                else if (yLoc <= mineHeight)
                {
                    tileType = 1;
                    //Debug.Log("Mine");
                }
                else
                {
                    tileType = 0;
                    //Debug.Log("Snow");
                }

                // World Generator
                loc = transform;
                tile = Instantiate(blocks[tileType], startLoc.position + new Vector3(xLoc, yLoc), startLoc.rotation);
                //world[world.Length - 1] = tile;
                //tile.transform.position = loc.position + new Vector3(xLoc/2, yLoc/2, 0);
                transform.position = new Vector3(loc.position.x, loc.position.y + 1);

                // Debug
                // yield return new WaitForSecondsRealtime(0.000001f);
                Debug.Log("Generated Tile");


                yLoc++;
            }

            // Reset for next tile array
            yLoc = 0f;
            xLoc++;
            transform.position = new Vector3(transform.position.x + 1, -worldHeight);
            //Debug.Log("Resetting Position");
        }
        //Debug.Log("Exiting world Gen");
        yield return 1;
        Time.timeScale = 1;
        //Debug.Log("Exited");
    }

    public int GetWorldSize()
    {
        return worldSize;
    }

    public int GetWorldHeight()
    {
        return worldHeight;
    }
}
