using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlatform : MonoBehaviour
{

    public GameObject platform;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            GameObject p;
            p = Instantiate(platform, new Vector2(Random.Range(-9, 9), -6), Quaternion.identity);

            timer = 0;

            p.transform.localScale = new Vector3(Random.Range(3,10), .2f);
        }
    }
}
