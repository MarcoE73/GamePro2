using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    public float speed;


    public Transform patrolPoints;

    private float waitTime;
    public float startWaitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float oldPosition;
    public float newPosition;

    private SpriteRenderer fishes;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        patrolPoints.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        fishes = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        oldPosition = transform.position.x;
        newPosition = patrolPoints.position.x;

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints.position, speed * Time.deltaTime);

        if(newPosition > oldPosition) {
            fishes.flipX = true;
        }
        else { fishes.flipX = false; }

        if (Vector2.Distance(transform.position, patrolPoints.position) <=  5f)
        {
            //fishes.flipX = true;
            if(waitTime <= 0)
            {
                patrolPoints.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            } else{
                waitTime -= Time.deltaTime;
            }
        }
    }
}
