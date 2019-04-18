using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;

    private GameControl control;

    public void SetGameControlReference(GameControl controller)
    {
        control = controller;
    }

    public void SetSpace()
    {
        buttonText.text = control.GetPlayerSide();
        button.interactable = false;
        control.EndTurn();
    }
}
