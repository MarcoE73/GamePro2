using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndChase : MonoBehaviour
{

    public float speed;
    public GameObject[] patrolPoints;
    int whichPoint;
    float distToPatrolPoint;
    float disToPlayer;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {

       

        disToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(disToPlayer <= 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed); //follows player
        }
        else //patrols empty objects
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed); 

            distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

            if (distToPatrolPoint < 0.05f)
            {
                whichPoint++;
                if (whichPoint >= patrolPoints.Length)
                {
                    whichPoint = 0;
                }
            }
        }
    }
}
