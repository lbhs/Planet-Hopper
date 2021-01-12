/*
 * KillShip.cs
 * Gavin Gee
 * 
 * This script handles any way that the ship can be destroyed leading to a game
 * over, with the exception of crashing into a planet (for now).
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillShip : MonoBehaviour
{ 
    void Death()
    {
        switch (gameObject.name)
        {
            case "DeathField": InfoScript.main.gameOverMessage = "Lost in Space...";
                break;
            case "Sun": InfoScript.main.gameOverMessage = "You Flew Too Close to the Sun!";
                break;
        }
        InfoScript.main.EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        Debug.Log(other.name);
        if (other.name == "Starship")
        {
            Debug.Log("Death activated");
            Death();
        }
    }
}
