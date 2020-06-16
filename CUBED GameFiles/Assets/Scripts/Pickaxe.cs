using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public int power;
    public int durability;
    public new string name;
    bool active = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && active == true)
        {
            //Debug.Log("Entered");
            transform.Rotate(0, 0, 10);
            //Debug.Log("Exit Loop");
        }
    }

    public int GetPower()
    {
        return power;
    }

    public string GetName()
    {
        return name;
    }
}
