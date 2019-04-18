using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoring : MonoBehaviour
{
    public Text scoreText;

    private void Awake()
    {
        scoreText.text = "SCORE: " + GameControl.control.score.ToString(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "scoreUp")
        {
            GameControl.control.score++;

            scoreText.text = "SCORE: " + GameControl.control.score.ToString();
        }

        if (collision.gameObject.tag == "scoreDown")
        {
            GameControl.control.score--;

            scoreText.text = "SCORE: " + GameControl.control.score.ToString();
        }
    }
}
