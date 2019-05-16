using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthPickup : MonoBehaviour
{
    //public GameObject Player;
    //public Slider Health;
    //public Player player;

    //public int healthPickup;

    //private void Start()
    //{
    //    Health = GetComponent<Slider>();
    //    //player.
    //}

    public Player player;

    private void Start()
    {
        //player.HealPlayer(10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.HealPlayer(10);
            Destroy(this.gameObject);
        }
    }
}
