using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public void GoToTutorial()
    {
        DontDestroyOnLoad(InfoScript.main.gameObject);
        SceneManager.LoadScene(3); // could be wrong?
    }
}
