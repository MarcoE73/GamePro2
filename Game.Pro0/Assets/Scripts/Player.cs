using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float health = 100f;

    int damage = 10;

    public GameObject deathEffect;
    public GameObject gameOverText, restartButton;


    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);

    }


    void Die()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            FindObjectOfType<AudioManager>().Play("ZombieAttack");
            HealthBarScript.health -= damage;
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }
    }
}
