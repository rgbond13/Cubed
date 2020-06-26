using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedVoxelManager : MonoBehaviour
{
    public GameObject tileInstance;
    public GameObject worldRenderer;
    int tilecount = 1;
    public string tileName;
    public bool active = true;
    public bool worth = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tilecount: " + tilecount);
        if (tilecount == 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!worth || transform.position.y < -worldRenderer.GetComponentInChildren<WorldRenderer>().GetWorldSize().y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tile Collided");
        if (collision.gameObject.tag == "TileDrop")
        {
            MergeTiles(collision);
        }

        if (collision.gameObject.tag == "Player")
        {
            AddToPlayerInventory();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            Debug.Log("A tile's tilecount is: " + GetTileCount());
        }
    }

    public int GetTileCount()
    {
        return tilecount;
    }

    public void AddTileCount(int tiles)
    {
        tilecount += tiles;
    }

    // This method regulates the tile combining
    private void MergeTiles(Collision collision)
    {
        Debug.Log("With another tile.");
        string collisionTileName = collision.gameObject.GetComponent<DroppedVoxelManager>().tileName;

        if (tilecount >= 99)
        {
            collision.gameObject.GetComponent<DroppedVoxelManager>().AddTileCount(tilecount - 99);
            AddTileCount(99 - tilecount);
            return;
        }
        else if (collision.gameObject.GetComponent<DroppedVoxelManager>().GetTileCount() >= 99)
        {
            return;
        }
        else if (collisionTileName == tileName && tilecount < 99)
        {
            if (tilecount > collision.gameObject.GetComponent<DroppedVoxelManager>().GetTileCount())
            {
                active = true;
            }
            else if (tilecount == collision.gameObject.GetComponent<DroppedVoxelManager>().GetTileCount())
            {
                while (collision.gameObject.GetComponent<DroppedVoxelManager>().active == active)
                {
                    if (Random.Range(1, 3) == 1)
                    {
                        Debug.Log("Case1");
                        active = false;
                        return;
                    }
                    else
                    {
                        active = true;
                    }
                }
            }
            else
            {
                active = false;
            }

            Debug.Log("Decided which tile is in charge");

            if (!active)
            {
                Debug.Log("Not active");
                return;
            }

            else
            {
                active = false;
            }
            Debug.Log(tileName);

            //Debug.Log("Merging tiles");

            int newTileCount = collision.gameObject.GetComponent<DroppedVoxelManager>().GetTileCount();

            //Debug.Log("Got tiles");
            AddTileCount(newTileCount);
            //Debug.Log("Added tiles");
            collision.gameObject.GetComponent<DroppedVoxelManager>().worth = false;
            //Debug.Log("Destroyed other tile");
            active = true;
            return;
        }
    }


    // This method regulates the adding of the tiles to the player's inventory.
    private void AddToPlayerInventory()
    {

    }


}