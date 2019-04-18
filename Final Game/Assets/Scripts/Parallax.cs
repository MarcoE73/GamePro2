using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;        
    private float[] parallaxScales;     
    public float smoothing = 1f;        

    private Transform cam;              
    private Vector3 previousCamPos;

    private float length, startpos;

    public float parallaxEffect;

    void Awake()
    {

        cam = Camera.main.transform;
    }

   
    void Start()
    {

        previousCamPos = cam.position;

       
        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

   
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dis = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dis, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    

        for (int i = 0; i < backgrounds.Length; i++)
        {

            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

       
        previousCamPos = cam.position;


    }


}
