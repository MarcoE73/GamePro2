using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float currentHealth;
    public static float maxHealth = 100f;
    public static int damage = 10;
    public static float drownDamage = 10f;
    public float time;

    public float drowning = 5f;

    public Slider Health;

    public AudioSource Hurt;

    public GameObject gameOverText, restartButton, healthPickup;


    void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        currentHealth = maxHealth ;
        Health.value = maxHealth;
        Debug.Log(Health.value + "Health" + currentHealth);
        time = 5;

        Hurt = GetComponent<AudioSource>();

    }

    private void Update()
    {
        //drowning -= 1 * Time.deltaTime;

        //if (drowning <= 0f)
        //{
        //    drowning = 5f;
        //    Drowning();

        //}

    }


    public void Drowning()
    {
        Health.value -= drownDamage;
    }


    public void Die()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        Destroy(gameObject);
        gameObject.SetActive(false);

    }
    public void TakeDamage(int damage)
    {
        //Debug.Log("Hitting = True");
        currentHealth -= damage;
        Health.value = currentHealth;
        if (currentHealth <= 0)
        {
            Health.fillRect.gameObject.SetActive(false);
            Die();
        }

    }

    public void HealPlayer(int heal)
    {
        currentHealth += heal;
        Health.value = currentHealth;
        if(currentHealth >= 100)
        {
            Health.fillRect.gameObject.SetActive(true);
            currentHealth = maxHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Hurt.Play();
            TakeDamage(10);
        }
    }
}

//currentHealth -= damage;
//Health.value -= damage;
//if (currentHealth <= 0)
//{
//    Die();
//}