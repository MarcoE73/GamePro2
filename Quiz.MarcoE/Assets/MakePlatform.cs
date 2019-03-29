using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlatform : MonoBehaviour {      public GameObject platform;     float timer = 0;
 
    void Start()
    {

    }
     void Update()     {
         timer += Time.deltaTime;          if (timer > 1)         {             GameObject p;


             p = Instantiate(platform, new Vector2(Random.Range(-12, 10), Random.Range(-8,7)), Quaternion.identity);

            


            timer = 0;
             p.transform.localScale = new Vector3(Random.Range(3,7), .2f);         }     } }  
