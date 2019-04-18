using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Player;
    public float cameraDistance = 30.0f;

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height ) / cameraDistance);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x , Player.position.y + 1, transform.position.z);
    
}
}