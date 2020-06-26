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
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = MaxSpeed;
        float jumpHeight = MaxJumpHeight;


        horiz = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        jump = Input.GetAxisRaw("Jump") * jumpHeight * Time.deltaTime;

        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 2.0f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector3.down, Color.green);

        string objectName;
        try
        {
            objectName = hit.collider.gameObject.name;
            touchingGround = true;
            Debug.Log("Touching Ground");
        }
        catch (System.NullReferenceException)
        {
            touchingGround = false;
            Debug.Log("Not touching ground");
        }
        //Debug.Log(hit.collider.gameObject.name);
        //Debug.Log(touchingGround);

        Vector3 moveVector = new Vector3(horiz, rb.velocity.y);

        if (touchingGround)
        {
            hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 2.0f);
            if (hit.distance < 1.237)
            {
                touchingGround = true;
            }
            else
            {
                touchingGround = false;
            }
            if (jump != 0)
            {

                moveVector = new Vector3(horiz, jump);
            }
        }

        rb.MovePosition(transform.position + moveVector);


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
