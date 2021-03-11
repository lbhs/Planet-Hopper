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
    public void Death()
    {
        switch (gameObject.name)
        {
            case "DeathField":
                InfoScript.main.EndGame("Lost in Space...");
                break;
            case "Sun":
                InfoScript.main.EndGame("You Flew Too Close to the Sun!");
                break;
            default:
                InfoScript.main.EndGame("You Crashed!");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        Debug.Log(other.name);
        if (other.name == "Starship" && gameObject.name == "CrashField")
        {
            Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Starship")
        {
            Death();
        }
    }
}
