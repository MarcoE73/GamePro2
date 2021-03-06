﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveInput;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Color PlayerColor;
    public GameObject ground;


    public bool faceR = true;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;
    

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow)) //makes player jump
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }
    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (faceR == true && moveInput < 0) //turn around flips character
        {
            Flip();
        }
        else if (faceR == false && moveInput > 0)
        {
            Flip();
        }
    }

    void Flip() //fliping code
    {
        faceR = !faceR;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Square")
        {
            PlayerColor = RandomColor.newcolor;

        }

        Color c = collision.gameObject.GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = c;
    }

}