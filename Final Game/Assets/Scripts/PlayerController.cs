using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveInput;
    private Rigidbody2D rb;

    public bool faceR = true;

    public float speed;
    float horz, vert;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        vert *= Time.deltaTime * speed;
        horz *= Time.deltaTime * speed;

        transform.Translate(horz, vert, 0);
    }
    private void FixedUpdate()
    {
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

}


