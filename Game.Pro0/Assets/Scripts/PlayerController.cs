using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveInput;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Animator animator;
    public float torque;

    public Vector3 respawnPoint;


    private bool faceR = true;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
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

    private void Flip() //fliping code
    {
        faceR = !faceR;

        transform.Rotate(0f, 180f, 0f);
        //Vector3 scaler = transform.localScale;
        //scaler.x *= -1;
        //transform.localScale = scaler;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            //Die();
            transform.position = respawnPoint;  
        }
        if(other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
}
