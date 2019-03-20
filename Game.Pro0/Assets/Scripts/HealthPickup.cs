using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject Player;
    public GameObject HeathBar;

    public int healthPickup;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponentInChildren<Player>().health += healthPickup;
            HealthBarScript.health += healthPickup;
            Destroy(this.gameObject);
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //        Player.health += healthPickup;
    //        HealthBarScript.health += healthPickup;
    //        Destroy(this.gameObject);
    //    }
    //}
}
