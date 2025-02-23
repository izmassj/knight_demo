using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;

    private float horMov;
    private float horVel = 4.0f;
    private float vertVel = 7f;
    private bool onGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void FixedUpdate()
    {
        MovementFixed();
        AnimationFixed();
    }

    void Movement() 
    {
        horMov = Input.GetAxisRaw("Horizontal");
        if (horMov != 0)
            transform.localScale = new Vector3(horMov , 1, 1);

        animator.SetFloat("Horizontal", Math.Abs(horMov * horVel));
        animator.SetBool("onGround", onGround);

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertVel);
            onGround = false; // Prevents double jumping
        }
    }

    void AnimationFixed() 
    {
        
    }

    void MovementFixed()
    {
        rb.velocity = new Vector2(horMov * horVel, rb.velocity.y);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
    }


}
