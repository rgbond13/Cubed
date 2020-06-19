using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedVoxelManager : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tile Collided");
        if (collision.gameObject.tag == "TileDrop")
        {
            Debug.Log("With another tile.");
            string collisionTileName = collision.gameObject.GetComponent<DroppedVoxelManager>().tileName;


            if (collisionTileName == tileName && tilecount < 99)
            {
                Debug.Log("Deciding which tile is in charge");
                if (Random.Range(1, 2) == 1)
                {
                    collision.gameObject.GetComponent<DroppedVoxelManager>().active = false;
                    Debug.Log("Case1");
                }
                if (collision.gameObject.GetComponent<DroppedVoxelManager>().active == true && active == true)
                {
                    active = false;
                    Debug.Log("Case2");
                    return;
                }
                else if (collision.gameObject.GetComponent<DroppedVoxelManager>().active == false && active == false)
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

                int newTileCount = collision.gameObject.GetComponent<DroppedVoxelManager>().GetTileCount() + tilecount;
                GameObject tile = Instantiate(tileInstance, transform.position, transform.rotation) as GameObject;
                tile.gameObject.GetComponent<DroppedVoxelManager>().AddTileCount(-1);
                tile.gameObject.GetComponent<DroppedVoxelManager>().AddTileCount(newTileCount);
                collision.gameObject.GetComponent<DroppedVoxelManager>().worth = false;
                return;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "TileDrop")
        {
            Debug.Log("A tile's tilecount is: " + collision.gameObject.GetComponent<DroppedVoxelManager>().GetTileCount());
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
