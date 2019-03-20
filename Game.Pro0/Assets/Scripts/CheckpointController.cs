using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite blueFlag;

    private SpriteRenderer checkpointSR;
    public bool checkpointReached;


    void Start()
    {
        checkpointSR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            checkpointSR.sprite = blueFlag;
            checkpointReached = true;
        }
    }
}
