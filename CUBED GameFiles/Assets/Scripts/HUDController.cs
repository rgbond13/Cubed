using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject[] hearts;
    public Texture damagedHeart;
    public Texture intactHeart;
    public GameObject player;
    PlayerController3D playerController;
    int currentHP;
    int prevHP;
    int maxHP;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController3D>();
        maxHP = playerController.GetMaxHP();
        prevHP = (int) Mathf.Round((float)playerController.GetHP() / maxHP * 10);
        Debug.Log("Init PrevHP: " + prevHP);
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = (int) Mathf.Round((float) playerController.GetHP() / maxHP * 10);
        Debug.Log("CurrentHP: " + currentHP);
        Debug.Log("PreviousHP: " + prevHP);
        if (currentHP < prevHP && currentHP >= 0)
        {
            for (int i = prevHP - 1; i > currentHP - 1; i--)
            {
                hearts[i].SetActive(false);
            }
        }
        else if (currentHP > prevHP && currentHP <= 10)
        {
            for (int i = prevHP - 1; i < currentHP - 1; i++)
            {
                hearts[i].SetActive(true);
            }
        }
        else if (currentHP == 10)
        {
            hearts[9].SetActive(true);
        }
        prevHP = currentHP;

        if (prevHP == 0)
        {
            prevHP++;
        }
    }
}
