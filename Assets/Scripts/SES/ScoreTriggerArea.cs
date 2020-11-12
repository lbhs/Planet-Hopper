using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerArea : MonoBehaviour
{ 
    public int id;
    private GameObject ship;

    private void Awake()
    {
        ship = GameObject.Find("Starship");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ship)
        {
            Debug.Log("Trigger Entered.");
            ScoreEvents.current.Landing(id);
        }
    }

    // checks if a landing is valid...
    /*
     * valid landing needs to:
     * - 
     */
    private void CheckLanding()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other == ship)
        {
            Debug.Log("Trigger Exited.");
            ScoreEvents.current.Leaving(id);
        }
    }
}
