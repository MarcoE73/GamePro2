using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAI : MonoBehaviour
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
    public float eyeSightOfFish;
    private float disToPlayer;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        patrolPoints.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fishes = GetComponent<SpriteRenderer>();
        //eyeSightOfFish = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        oldPosition = transform.position.x;
        newPosition = patrolPoints.position.x;
        //Debug.Log("Test " + (disToPlayer <= eyeSightOfFish));

        if (newPosition > oldPosition)
        {
            fishes.flipX = true;
        }
        else { fishes.flipX = false; }

        disToPlayer = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints.position, speed * Time.deltaTime);

        if (disToPlayer <= eyeSightOfFish)
        {
            //Debug.Log("Following the player " + disToPlayer);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, patrolPoints.position) <= 0.2f)
        {
            if (waitTime <= 0)
            {
                patrolPoints.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
