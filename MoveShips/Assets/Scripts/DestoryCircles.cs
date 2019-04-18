using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCircles : MonoBehaviour
{
    float timer = 0;


    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            Destroy(this.gameObject);
        }
    }
}
