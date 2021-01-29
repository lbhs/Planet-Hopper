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
        UpdateScoreText();
        UpdateGameOverText();
    }

    void UpdateGameOverText()
    {
        gameOverText.text = "" + InfoScript.main.gameOverMessage;
    }

    void UpdateScoreText()
    {
        scoreText.text = "" + InfoScript.main.score; // sorry I know this looks gross
    }

    public void RestartGame()
    {
        InfoScript.main.StartGame();
    }
}
