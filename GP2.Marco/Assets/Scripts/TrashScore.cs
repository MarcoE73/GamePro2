using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashScore : MonoBehaviour
{
    public Text scoreText;
   
    public SpriteRenderer dirtyWater;

    public float decreaseAlpha = .1f;
    public float alphaLevel = 1f;


    public void Start()
    {
        scoreText.text = "Trash Collected: " + GameControl.control.score.ToString();
    }

    private void SetWaterOpacity(float opacity)
    {
        Color newColor = dirtyWater.color;
        //newColor.a = opacity;
        newColor.a -= opacity;
        dirtyWater.color = newColor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameControl.control.score++;
            Destroy(this.gameObject);

            scoreText.text = "Trash Collected: " + GameControl.control.score.ToString();

            //dirtyWater.color = new Color(1, 1, 1, alphaLevel);
            //alphaLevel -= decreaseAlpha;

            //Debug.Log("Alpha Lvevel" + dirtyWater.color);
            SetWaterOpacity(decreaseAlpha);
        }
    }
}
