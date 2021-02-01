using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialNavi : MonoBehaviour
{
    public void GoToGameplay()
    {
        DontDestroyOnLoad(InfoScript.main);
        DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(0); // add ID of gameplay scene
    }

    public void GoToRules()
    {
        DontDestroyOnLoad(InfoScript.main);
        DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(0); // add ID of rules scene
    }

    public void GoToTutorialMenu()
    {
        DontDestroyOnLoad(InfoScript.main);
        DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(3); // add ID of rules scene
    }
}
