using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered.");
        ScoreEvents.current.Landing();
    }

    private void OnTriggerExit()
    {
        Debug.Log("Trigger Exited.");
        ScoreEvents.current.Leaving();
    }
}
