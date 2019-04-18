using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    public float cameraDistance = 60f;

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = 5f;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
