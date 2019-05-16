using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderingCrab : MonoBehaviour
{
    public float speed;

    public Transform[] patrolPoints;
    private int randomSpots;
    private float waitTime;
    public float startWaitTime;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpots = Random.Range(0, patrolPoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomSpots].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[randomSpots].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpots = Random.Range(0, patrolPoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

