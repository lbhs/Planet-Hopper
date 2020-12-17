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
 * TODO: More variables will be kept track of once the Score Event System is in place.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoScript : MonoBehaviour
{
    //
    public static InfoScript main;

    private float currentFuel;

    // These bools record which planets the player has landed on.
    private bool mercuryVisited = false;
    private bool venusVisited = false;
    private bool earthVisited = false;
    private bool marsVisited = false;
    private bool jupiterVisited = false;
    private bool saturnVisited = false;
    private bool uranusVisited = false;
    private bool neptuneVisited = false;

    /* This is the player's score. Currently, it doesn't do anything, but it is
     * useful to keep track of it here.
     */
    public int score = 0;

    /* This is a constant score value that is given on a successful landing.
     * (This is really just being used for testing the SES).
     */
    private const int missionSuccessConstant = 1000;

    private GameObject scoreValue;

    // This function starts the game and assigns values to the planet bools based on the user's selections.
    public void StartGame()
    {
        score = 0;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1); // change me back to 1 later!!
    }

    private void Awake()
    {
        main = this;
    }

    public void UpdateScore(string planet)
    {
        if (!AlreadyVisited(planet))
        {
            score += missionSuccessConstant + (int)ShipController.main.Fuel;
            scoreValue = GameObject.Find("ScoreValue");
            scoreValue.GetComponent<Text>().text = "Score: " + score;
        }
    }

    private bool AlreadyVisited(string planet)
    {
        bool isVisited;
        switch (planet)
        {
            case "Mercury": isVisited = mercuryVisited;
                mercuryVisited = true;
                break;
            case "Venus": isVisited = venusVisited;
                venusVisited = true;
                break;
            case "Earth": isVisited = earthVisited;
                earthVisited = true;
                break;
            case "Mars": isVisited = marsVisited;
                marsVisited = true;
                break;
            case "Jupiter": isVisited = jupiterVisited;
                jupiterVisited = true;
                break;
            case "Saturn": isVisited = saturnVisited;
                saturnVisited = true;
                break;
            case "Uranus": isVisited = uranusVisited;
                uranusVisited = true;
                break;
            case "Neptune": isVisited = neptuneVisited;
                neptuneVisited = true;
                break;
            default: return false;
        }
        return isVisited;
    }

}
