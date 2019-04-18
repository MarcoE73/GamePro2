using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public Text[] buttonList;
    private string XorO;
    private int moveCount;

    // Start is called before the first frame update
    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        XorO = "X";
        moveCount = 0;
    }

    void SetGameControllerReferenceOnButtons()
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControlReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return XorO;
    }

    public void EndTurn()
    {
        if(buttonList[0].text == XorO && buttonList[1].text == XorO && buttonList[2].text == XorO) //copy and paste this for other wins
        {
            GameOver(XorO);
        }

        XorO = (XorO == "X") ? "O" : "X"; // "?" equals if , ":" equals otherwise!

        moveCount++;
        if(moveCount >= 9)
        {
            GameOver("No one");
        }
    }

    void GameOver(string whois)
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }

        Debug.Log(whois + " is the winner");
    }
}
