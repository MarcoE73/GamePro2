using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickUpController : MonoBehaviour
{
    public GameObject Player;

    public int AmmoIncrease;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponentInChildren<Weapon>().maxAmmo += AmmoIncrease;
            Destroy(this.gameObject);
        }
       
    }
}
