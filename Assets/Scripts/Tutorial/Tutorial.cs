using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public void GoToTutorial()
    {
        DontDestroyOnLoad(InfoScript.main);
        //DontDestroyOnLoad(InfoScript.main.music);
        SceneManager.LoadScene(3); // could be wrong?
    }
}
