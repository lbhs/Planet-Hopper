using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillShip : MonoBehaviour
{ 
    void Death()
    {
        DontDestroyOnLoad(InfoScript.main.gameObject); // keeps the "Info" gameobject alive
        SceneManager.LoadScene(2); // Load the end scene. TODO: Add something that differentiates this end scene with the others?
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
