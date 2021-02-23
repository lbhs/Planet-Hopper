using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetSwitch : MonoBehaviour
{
    public Text PausedText;
    public GameObject Resume;
    public GameObject Restart;

    void Start()
    {
        Resume.SetActive(false);
        Restart.SetActive(false);
        PausedText.enabled = false;
    }

    public void Change()
    {
        if (Time.timeScale == 1)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Resume.SetActive(true);
        Restart.SetActive(true);
        PausedText.enabled = true;
    }

    public void ResumeGame()
    {
        Resume.SetActive(false);
        Restart.SetActive(false);
        PausedText.enabled = false;
        Time.timeScale = 1;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
