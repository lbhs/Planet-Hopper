using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoScript : MonoBehaviour
{
    
    private bool doMercury = true;
    private bool doVenus = true;
    private bool doEarth = true;
    private bool doMars = true;
    private bool doJupiter = true;
    private bool doSaturn = true;
    private bool doUranus = true;
    private bool doNeptune = true;


    public void StartGame()
    {
        doMercury = GameObject.Find("Mercury Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        doVenus = GameObject.Find("Venus Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        doEarth = GameObject.Find("Earth Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        doMars = GameObject.Find("Mars Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        doJupiter = GameObject.Find("Jupiter Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        doSaturn = GameObject.Find("Saturn Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        doUranus = GameObject.Find("Uranus Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        doNeptune = GameObject.Find("Neptune Toggle").GetComponent<PlanetActiveToggle>().isSelected;

        DontDestroyOnLoad(gameObject); // TODO: ?? Come back to me later!!
        // Load next scene?
        SceneManager.LoadScene(1);
    }

}
