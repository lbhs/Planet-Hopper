/**
 * 
 * InfoScript.cs
 * Written by Gavin Gee
 * 
 * This script is to be placed on the `Info` Game Object. It will hold a majority
 * of the valuable information in the game. Currently, it keeps track of:
 * 
 * - The Planets that are to be spawned at the beginning of the game.
 * - The Player's score.
 * 
 * TODO: More variables will be kept track of once the Score Event System (SES) 
 * is in place. This script will work closely with the SES.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoScript : MonoBehaviour
{
    // These bools control which planets of the solar system will be spawned.
    private bool mercuryEnabled = true;
    private bool venusEnabled = true;
    private bool earthEnabled = true;
    private bool marsEnabled = true;
    private bool jupiterEnabled = true;
    private bool saturnEnabled = true;
    private bool uranusEnabled = true;
    private bool neptuneEnabled = true;

    /* This is the player's score. Currently, it doesn't do anything, but it is
     * useful to keep track of it here.
     */
    public int score = 0;

    /* This is a constant score value that is given on a successful landing.
     * (This is really just being used for testing the SES).
     */
    private const int missionSuccessConstant = 1000;

    // This function starts the game and assigns values to the planet bools based on the user's selections.
    public void StartGame()
    {
        mercuryEnabled = GameObject.Find("Mercury Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        venusEnabled = GameObject.Find("Venus Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        earthEnabled = GameObject.Find("Earth Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        marsEnabled = GameObject.Find("Mars Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        jupiterEnabled = GameObject.Find("Jupiter Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        saturnEnabled = GameObject.Find("Saturn Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        uranusEnabled = GameObject.Find("Uranus Toggle").GetComponent<PlanetActiveToggle>().isSelected;
        neptuneEnabled = GameObject.Find("Neptune Toggle").GetComponent<PlanetActiveToggle>().isSelected;

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(2); // change me back to 1 later!!
    }

    public void UpdateScore()
    {
        score += missionSuccessConstant;
        Debug.Log(score);
        // GameObject.Find("Score Text").GetComponent<Text>().text = "Score: " + score; TODO: add `Score Text` into the scene. 
    }

}
