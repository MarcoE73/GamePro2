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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameControl.control.score++;
            Destroy(this.gameObject);

            scoreText.text = "SCORE: " + GameControl.control.score.ToString();
        }
    }
}
