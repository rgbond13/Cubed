using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    RaycastHit hit;
    float jump;
    float horiz;
    Rigidbody2D rb;
    public float speed;
    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        jump = Input.GetAxis("Jump") * Time.deltaTime * jumpHeight;

        Debug.Log("Horiz: " + horiz);
        Debug.Log("Jump: " + jump);

        // rb.velocity = new Vector2(horiz, jump);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
