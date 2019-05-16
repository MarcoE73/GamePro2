using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider Health;
    //Image healthBar;
    public static float maxHealth = 100f;
    public static float health;
    //public static float healthBarFill;

    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<Slider>();
        //healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //HealthBarFilling();
        //Health.value = health - Player.damage;
        //healthBar.fillAmount = health / maxHealth;
    }

    // public void HealthBarFilling()
    //{
    //    healthBar.fillAmount = health / maxHealth;
    //}

}

//public Slider Health;
//Image healthBar;
//public static float maxHealth = 100f;
//public static float health;
////public static float healthBarFill;

//// Start is called before the first frame update
//void Start()
//{
//    healthBar = GetComponent<Image>();
//    health = maxHealth;
//    //healthBarFill = healthBar.fillAmount = health / maxHealth;
//}

//// Update is called once per frame
//void Update()
//{
//    HealthBarFilling();
//    //healthBar.fillAmount = health / maxHealth;
//}

// public void HealthBarFilling()
//{
//    healthBar.fillAmount = health / maxHealth;
//}