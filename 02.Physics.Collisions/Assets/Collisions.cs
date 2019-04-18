using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision!");

        if (other.gameObject.tag == "sphere")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else { 
                GetComponent<Renderer>().material.color = Color.yellow;
                GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }

    }
    void OnCollisionStay(Collision other)
    {
        Debug.Log("I'm touching!!");
    }
    void OnCollisionExit(Collision other)
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

}
