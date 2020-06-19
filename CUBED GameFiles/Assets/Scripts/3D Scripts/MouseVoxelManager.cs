using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVoxelManager : MonoBehaviour
{
    public GameObject player;
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
            
        }
        else
        {
            Debug.Log("No RaycastHit");
        }

        Debug.DrawRay(mainCamera.transform.position, transform.position - mainCamera.transform.position, Color.green);
    }


    private void OnTriggerStay2D(Collider2D collision)
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = 0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TileDrop")
        {
            Debug.Log("A tile's tilecount is: " + collision.gameObject.GetComponent<DroppedTileManager>().GetTileCount());
        }
    }
}
