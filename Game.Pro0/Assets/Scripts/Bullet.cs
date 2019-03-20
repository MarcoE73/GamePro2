using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb2d;


    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.75f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag == "enemy")
        {
            hitInfo.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

