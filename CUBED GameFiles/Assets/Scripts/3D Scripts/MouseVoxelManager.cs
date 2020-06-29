using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVoxelManager : MonoBehaviour
{
    public GameObject[] placeableTiles;
    public GameObject placeLoc;
    public GameObject player;
    public LayerMask tiles;
    bool pickaxeActive = true;
    BoxCollider bcollider;
    float timer = 0f;
    public Transform mainCamera;
    RaycastHit hit;

    void Start()
    {
        bcollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainCamera.transform.position;
        transform.rotation = mainCamera.transform.rotation;
        transform.Translate(new Vector3(0, 0, 19));

        Ray blockRaycast = new Ray(mainCamera.transform.position, transform.position - mainCamera.transform.position);

        if (Physics.Raycast(blockRaycast, out hit, 15))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (hit.collider.gameObject.tag == "Tile")
                {
                    int power = player.GetComponentInChildren<Pickaxe>().GetPower();

                    hit.collider.gameObject.GetComponent<VoxelManager>().DamageBlock(power);
                    //Debug.Log("Block Damaged");
                    timer = 0.3f;
                }
                else
                {
                    Debug.Log("Hit");
                }
                Debug.Log(hit.collider.gameObject.tag);
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Debug.Log("Prepare to place tile");
                if (hit.collider.gameObject.tag == "Tile")
                {
                    PlaceBlock(hit.point, hit);
                }
            }
            
        }
        else
        {
            //Debug.Log("No RaycastHit");
        }

        Debug.DrawRay(mainCamera.transform.position, transform.position - mainCamera.transform.position, Color.green);
    }


    private void OnTriggerStay(Collider collision)
    {
        //Debug.Log("Collision");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            timer -= Time.deltaTime;
            //Debug.Log("Working Collision");

            if (timer <= 0f)
            {
                //Debug.Log("Mining");
                if (collision.gameObject.tag == "Tile")
                {
                    int power = player.GetComponentInChildren<Pickaxe>().GetPower();

                    collision.gameObject.GetComponent<TileManager>().DamageBlock(power);
                    //Debug.Log("Block Damaged");
                    timer = 0.3f;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        timer = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "TileDrop")
        {
            Debug.Log("A tile's tilecount is: " + collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount());
        }
    }

    private void PlaceBlock(Vector3 contact, RaycastHit hit)
    {
        Debug.Log("Before Rounding: " + contact);
        contact = new Vector3(Mathf.RoundToInt(contact.x), Mathf.RoundToInt(contact.y), Mathf.RoundToInt(contact.z));
        Debug.Log("Rounded RaycastHit.Point");
        Debug.Log("Contact: " + contact + "\nHit.collider.gameObject.transform.position: " + hit.collider.gameObject.transform.position);
        
        placeLoc.transform.position = contact;
        
        if (Physics.OverlapBox(contact, hit.transform.localScale / 2, Quaternion.identity, tiles).Length == 0)
        {
            Debug.Log("Created Tile");
            GameObject voxel = Instantiate(placeableTiles[3], placeLoc.transform) as GameObject;
            voxel.transform.parent = null;
            Debug.Log("Contact point: " + contact);
        }
    }
}
