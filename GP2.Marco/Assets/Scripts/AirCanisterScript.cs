using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirCanisterScript : MonoBehaviour
{
    public Slider air;
    public static float health;
    public int damage;
    public static float timeStart = 300f;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        //damage = player.damage
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Air " + air.value + "Health :" + Player.health);
        air.value = timeStart -= Time.deltaTime;

        if (timeStart <= 0)
        {
            air.fillRect.gameObject.SetActive(false);


            player.drowning -= 1 * Time.deltaTime;

            if (player.drowning <= 0f)
            {
                player.drowning = 5f;
                player.Drowning();

            }
        }
        else if(timeStart >= 0)
        {
            air.fillRect.gameObject.SetActive(true);
        }
    }
}

