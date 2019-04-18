using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{

    public Text scoreText;
    public Sildey;
    int score = 0;

    void Start()
    {
        scoreText.text = "score = " score.ToString();
        slidey.value = score;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "coin") 
        {
            score++;

            slidey.value = score;

            if (score == 4)
            {
                scoreText.text = "WINNER";
            }
            else 
            {
                scoreText.text = "score = " score.ToString();
            }

            Destroy(collision.gameObject);
            Debug.Log(score);
        }

    }
}
