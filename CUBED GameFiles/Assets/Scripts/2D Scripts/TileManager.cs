﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public int tile;
    public int tileBreakTime;
    
    int hitPoints;

    BoxCollider2D hitBox;
    public GameObject drop;

    void Start()
    {
        hitPoints = tileBreakTime;
        hitBox = GetComponent<BoxCollider2D>();
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
            GameObject tile = Instantiate(drop, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
    }

}
