using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    public GameObject door;
    private bool isOpened = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Buddah")
        {
            if (!isOpened)
            {
                isOpened = true;
                door.transform.position += new Vector3(0, 4, 0);
            }

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Buddah")
        {
            if(isOpened == true)
            {
                door.transform.position += new Vector3(0, 0, 0);
            }
        }
    }

}

