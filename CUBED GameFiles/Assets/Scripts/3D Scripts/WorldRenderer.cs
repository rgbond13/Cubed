using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRenderer : MonoBehaviour
{
    public GameObject[] blocks;
    public Transform startLoc;
    public Vector3 worldSize;
    //public int worldHeight;
    //public int worldWidth;
    //public int worldLength;
    public Vector3 chunkSize;
    
    GameObject tile;
    Transform loc;
    private int tileType = 0;
    private float xLoc = 1f;
    private float yLoc = 0f;
    private float zLoc = 0f;
    public float yHeight;
    public float mineHeight;
    public float underWorldHeight;
    public GameObject[,,] world;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; 
        transform.position = new Vector3(-worldSize.x + 1, -worldSize.y, -worldSize.z);
        StartCoroutine("WorldGenerator");
        Debug.Log("Continuing Routine");
    }


    IEnumerator WorldGenerator()
    {
        while (zLoc < chunkSize.z)
        {
            while (xLoc < chunkSize.x)
            {
                while (transform.position.y < yHeight)
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

                    // Column Generator
                    loc = transform;
                    tile = Instantiate(blocks[tileType], startLoc.position + new Vector3(xLoc, yLoc, zLoc), startLoc.rotation);
                    //world[world.Length - 1] = tile;
                    //tile.transform.position = loc.position + new Vector3(xLoc/2, yLoc/2, 0);
                    transform.position = new Vector3(loc.position.x, loc.position.y + 1, loc.position.z);

                    // Debug
                    //yield return new WaitForSecondsRealtime(0.01f);
                    //Debug.Log("Generated Tile");
                    //Debug.Log(yLoc);


                    yLoc++;
                }

                // Reset for next tile row
                yLoc = 0f;
                xLoc++;
                transform.position = new Vector3(transform.position.x + 1, -chunkSize.y, transform.position.z);
                //Debug.Log("Resetting Position");
            }

            // Reset for next tile column
            xLoc = 0f;
            zLoc++;
            transform.position = new Vector3(-chunkSize.x, chunkSize.y, transform.position.z + 1);
            //Debug.Log(transform.position.z <= worldWidth);
            //Debug.Log(worldWidth);
            //Debug.Log(transform.position.z);
            //Debug.Log("Next Z Row");

        }
        

        Debug.Log("Exiting world Gen");
        yield return 1;
        Time.timeScale = 1;
        Debug.Log("Exited");
    }

    public Vector3 GetWorldSize()
    {
        return worldSize;
    }

}
