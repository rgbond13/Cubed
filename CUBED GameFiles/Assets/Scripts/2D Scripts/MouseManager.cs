using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public GameObject player;
    bool pickaxeActive = true;
    BoxCollider2D bcollider;
    float timer = 0f;

    void Start()
    {
        bcollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 16;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = mouse;

        //Ray blockRaycast = new Ray(Camera.main.transform.position, mouse - Camera.main.transform.position);

        //if (Physics.Raycast(blockRaycast, out hit, 25))
        //{
        //    if (hit.collider.gameObject.tag == "Tile")
        //    {
        //        Debug.Log("Tile Hit");
        //    }
        //    else
        //    {
        //        Debug.Log("Hit");
        //    }
        //    Debug.Log(hit.collider.gameObject.tag);
        //}
        //else
        //{
        //    Debug.Log("No RaycastHit");
        //}
        //Debug.DrawLine(Camera.main.transform.position, mouse - Camera.main.transform.position, Color.green);
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
