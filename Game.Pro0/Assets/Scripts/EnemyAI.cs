using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAI : MonoBehaviour
{
    public int damage;

    public Transform target;

    public float engaugeDistance = 10f;

    public float attackDistance = 3f;

    public float moveSpeed;

    private bool facingLeft = true;

    private Animator anim;

    //public GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {


        anim.SetBool("IsAttacking", false);
        if(Vector3.Distance(target.position, this.transform.position) < engaugeDistance)
        {

            Vector3 direction = target.position - this.transform.position;

            if(Mathf.Sign(direction.x) == 1 && facingLeft)
            {
                Flip();
            }
            else if (Mathf.Sign(direction.x) == -1 && !facingLeft)
            {
                Flip();
            }

            if(direction.magnitude >= attackDistance)
            {


                Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);

                if (facingLeft)
                {
                    this.transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
                }
                else if (!facingLeft)
                {

                    this.transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
                }
            }

            if(direction.magnitude < attackDistance)
            {

                Debug.DrawLine(target.transform.position, this.transform.position, Color.red);
                anim.SetBool("IsAttacking", true);
            }
        }

        else if (Vector3.Distance(target.position, this.transform.position) > engaugeDistance)
        {
            Debug.DrawLine(target.position, this.transform.position, Color.green);
        }
    }
    void Flip()
    {
        facingLeft = !facingLeft;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}
