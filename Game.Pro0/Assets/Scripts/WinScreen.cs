using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public int sceneToLoad;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 50, 100, 40), "Play Again"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }

}