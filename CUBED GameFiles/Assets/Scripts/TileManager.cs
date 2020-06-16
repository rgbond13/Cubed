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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hitPoints -= collision.gameObject.GetComponent<Pickaxe>().GetPower();
        
    }

    public void DamageBlock(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            Instantiate(drops[tile], transform);
        }
    }

}
