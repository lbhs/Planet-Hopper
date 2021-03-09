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
    public List<GameObject> UIStuff;
    public List<GameObject> ToEnable;
    public GameObject Closest;
    public GameObject Selected;
    public GameObject PlanetMenu;

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
        PlanetMenu.GetComponent<PlanetMenu>().StopCor();
        foreach (GameObject UI in UIStuff)
        {
            if (UI.active == false)
            {
                ToEnable.Add(UI);
            }
            else
            {
                UI.SetActive(false);
            }
        }
        Selected.SetActive(false);
    }

    public void ResumeGame()
    {
        Resume.SetActive(false);
        Restart.SetActive(false);
        PausedText.enabled = false;
        Time.timeScale = 1;
        foreach (GameObject UI in UIStuff)
        {
            if (ToEnable.Contains(UI) == false)
            {
                UI.SetActive(true);
            }
        }
        ToEnable.Clear();
        if (Closest.active == true)
        {
            PlanetMenu.GetComponent<PlanetMenu>().StartCor();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
