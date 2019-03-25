using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    float moveHorizontal;
    float moveVertical;
    bool isGrounded;
    Vector2 movement;
    public float speed;
    public float jumpHeight;
    Rigidbody2D rb;
    Animator a;

    // Start is called before the first frame update
    void Start()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        a.Play("Run");
        isGrounded = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        run();
        jump();
    }


    void run()
    {
        movement = new Vector2(moveHorizontal + speed, 0);
        rb.velocity = movement;
    }

    void jump()
    {
        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            transform.DOMoveY(transform.position.y + jumpHeight, 0.4f);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}
