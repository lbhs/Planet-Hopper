using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText.text = "" + InfoScript.main.score; // I know this looks gross :( I'll (probably) fix this later.
    }

    public void RestartGame()
    {
        InfoScript.main.StartGame();
    }
}
