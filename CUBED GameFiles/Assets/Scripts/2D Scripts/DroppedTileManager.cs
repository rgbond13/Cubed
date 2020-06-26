using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedTileManager : MonoBehaviour
{
    public GameObject tileInstance;
    public GameObject worldGenerator;
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
        if (!worth || transform.position.y < -worldGenerator.GetComponentInChildren<WorldGeneration>().GetWorldHeight())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

    private void OnTriggerStay2D(Collider2D collision)
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
    private void MergeTiles(Collision2D collision)
    {
        Debug.Log("With another tile.");
        string collisionTileName = collision.gameObject.GetComponent<DroppedTileManager>().tileName;

        if (tilecount >= 99)
        {
            collision.gameObject.GetComponent<DroppedTileManager>().AddTileCount(tilecount - 99);
            AddTileCount(99 - tilecount);
            return;
        }
        else if (collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount() >= 99)
        {
            return;
        }
        else if (collisionTileName == tileName && tilecount < 99)
        {
            if (tilecount > collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount())
            {
                active = true;
            }
            else if (tilecount == collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount())
            {
                while (collision.gameObject.GetComponent<DroppedTileManager>().active == active)
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

            int newTileCount = collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount();

            //Debug.Log("Got tiles");
            AddTileCount(newTileCount);
            //Debug.Log("Added tiles");
            collision.gameObject.GetComponent<DroppedTileManager>().worth = false;
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
