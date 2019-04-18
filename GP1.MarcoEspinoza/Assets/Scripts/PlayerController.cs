using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveInput;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;


    public bool faceR = true;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;

    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
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
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.tag == "Spikes")
            {
                transform.position = respawnPoint;
            }
            if(collision.tag == "CheckPoint")
            {
                respawnPoint = collision.transform.position;
            }
        }
    }

}
