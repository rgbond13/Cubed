using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public int tile;
    public int tileBreakTime;
    
    int hitPoints;

    CircleCollider2D hitBox;
    GameObject[] drops;

    void Start()
    {
        hitPoints = tileBreakTime;
        hitBox = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitPoints -= collision.gameObject.GetComponent<Pickaxe>().GetPower();
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            Instantiate(drops[tile], transform);
        }
    }
}
