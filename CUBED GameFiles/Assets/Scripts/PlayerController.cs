using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float jump;
    float horiz;
    public Rigidbody2D rb;
    public float MaxSpeed;
    public float MaxJumpHeight;
    public BoxCollider2D grounded;
    bool touchingGround;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed;
        float jumpHeight = MaxJumpHeight;

        if (rb.velocity.y >= 10)
        {
            speed = 0;
        }
        else
        {
            speed = MaxSpeed;
        }


        horiz = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        jump = Input.GetAxisRaw("Jump") * jumpHeight * Time.deltaTime;

        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 2.0f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector3.down, Color.green);
        Debug.Log(hit.distance);
        Debug.Log(hit.collider.gameObject.name);
        if (hit.distance < 1.237)
        {
            touchingGround = true;
        }
        else
        {
            touchingGround = false;
        }
        Debug.Log(touchingGround);
        rb.velocity = new Vector2(horiz, rb.velocity.y);
        if (touchingGround)
        {
            if (jump != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
        }

        
        

        if (jump != 0 )
        {
            //rb.velocity = new Vector2(horiz, jump);
            //rb.AddForce(new Vector2(0, jump));
        }

        //Debug.Log("Horiz: " + horiz);
        //Debug.Log("Jump: " + jump);

        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    touchingGround = true;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    touchingGround = false;
    //}
}
