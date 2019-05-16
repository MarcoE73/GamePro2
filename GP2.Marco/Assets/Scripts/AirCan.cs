using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCan : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            AirCanisterScript.timeStart = 300f;
            Destroy(gameObject);
        }
    }
}
