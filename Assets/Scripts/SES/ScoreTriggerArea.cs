using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerArea : MonoBehaviour
{ 
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Starship")
        {
            Debug.Log("Trigger Entered.");
            ScoreEvents.current.Landing(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Starship")
        {
            Debug.Log("Trigger Exited.");
            ScoreEvents.current.Leaving(id);
        }
    }
}
