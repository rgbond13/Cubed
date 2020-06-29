using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public GameObject worldRenderer;
    public int hp;
    public int maxHP;


    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -worldRenderer.GetComponentInChildren<WorldRenderer>().GetWorldSize().y)
        {
            Camera.main.transform.parent = null;
            Camera.main.transform.eulerAngles = new Vector3(90, 0);
            Destroy(Camera.main.GetComponent<CameraManager>());
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            hp -= Random.Range(4, 12);
            if (hp < 0)
            {
                hp = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            hp += Random.Range(4, 12);
            if (hp > 100)
            {
                hp = 100;
            }
        }
        Debug.Log("Raw HP: " + hp);
    }

    public int GetHP()
    {
        return hp;
    }

    public int GetMaxHP()
    {
        return maxHP;
    }
}
