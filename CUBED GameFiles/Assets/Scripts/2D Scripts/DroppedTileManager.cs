using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedTileManager : MonoBehaviour
{
    public GameObject tileInstance;
    int tilecount = 1;
    public string tileName;
    public bool active = true;
    public bool worth = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tilecount: " + tilecount);
        if (tilecount == 0) { }
    }

    // Update is called once per frame
    void Update()
    {
        if (!worth)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Tile Collided");
        if (collision.gameObject.tag == "TileDrop")
        {
            Debug.Log("With another tile.");
            string collisionTileName = collision.gameObject.GetComponent<DroppedTileManager>().tileName;
            
        
            if (collisionTileName == tileName && tilecount < 99)
            {
                Debug.Log("Deciding which tile is in charge");
                if (Random.Range(1, 2) == 1)
                {
                    collision.gameObject.GetComponent<DroppedTileManager>().active = false;
                    Debug.Log("Case1");
                }
                if (collision.gameObject.GetComponent<DroppedTileManager>().active == true && active == true)
                {
                    active = false;
                    Debug.Log("Case2");
                    return;
                }
                else if (collision.gameObject.GetComponent<DroppedTileManager>().active == false && active == false)
                {
                    active = true;
                    Debug.Log("Case3");
                }

                if (!active)
                {
                    return;
                }

                Debug.Log(tileName);

                Debug.Log("Merging tiles");

                int newTileCount = collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount() + tilecount;
                GameObject tile = Instantiate(tileInstance, transform.position, transform.rotation) as GameObject;
                tile.gameObject.GetComponent<DroppedTileManager>().AddTileCount(-1);
                tile.gameObject.GetComponent<DroppedTileManager>().AddTileCount(newTileCount);
                collision.gameObject.GetComponent<DroppedTileManager>().worth = false;
                return;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TileDrop")
        {
            Debug.Log("A tile's tilecount is: " + collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount());
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


}
