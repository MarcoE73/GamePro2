using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public GameObject door;
    private bool isOpened = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isOpened)
            {
                isOpened = true;
                door.transform.position += new Vector3(10, 0, 0);
            }

        }
    }
}
