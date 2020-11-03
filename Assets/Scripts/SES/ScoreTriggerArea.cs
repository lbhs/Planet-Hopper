using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerArea : MonoBehaviour
{ 
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered.");
        ScoreEvents.current.Landing(id);
    }

    private void OnTriggerExit()
    {
        Debug.Log("Trigger Exited.");
        ScoreEvents.current.Leaving(id);
    }
}
