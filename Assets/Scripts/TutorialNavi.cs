using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialNavi : MonoBehaviour
{
    public static TutorialNavi main;
    public int numGreen; // TODO: private this and make it publically accessible

    private void Start()
    {
        main = this;
        numGreen = 0;
    }

    public void GoToTGameplay1()
    {
        DontDestroyOnLoad(InfoScript.main);
        //DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(4); // add ID of gameplay scene
    }

    public void GoToTGameplay2()
    {
        DontDestroyOnLoad(InfoScript.main);
        //DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(5); // add ID of gameplay scene
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToRules()
    {
        DontDestroyOnLoad(InfoScript.main);
        //DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(0); // add ID of rules scene
    }

    public void GoToTutorialMenu()
    {
        DontDestroyOnLoad(InfoScript.main);
        //DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(3);
    }



    

    
}
