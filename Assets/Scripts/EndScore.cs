using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;

    void Start()
    {
        scoreText.text = "" + InfoScript.main.score; // sorry I know this looks gross
        gameOverText.text = "" + InfoScript.main.gameOverMessage;
    }

    public void RestartGame()
    {
        InfoScript.main.StartGame();
    }
}
