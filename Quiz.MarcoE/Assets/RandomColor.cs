using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public static Color newcolor;


    // Start is called before the first frame update
    public void Start()
    {
        newcolor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        gameObject.GetComponent<Renderer>().material.color = newcolor;

    }

}
