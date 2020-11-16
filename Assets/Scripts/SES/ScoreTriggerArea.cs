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
            Debug.Log(CheckLanding());
            ScoreEvents.current.Landing(id);
        }
    }

    // checks if a landing is valid...
    /*
     * valid landing needs to:
     * - be under a certain speed ( < 100 for now but this can be adjusted )
     * - be rotated away from the planet ( angle < 10 )
     */
    private bool CheckLanding()
    {
        // checks the speed of the ship
        //if (ship.GetComponent<Rigidbody>().velocity.magnitude > 100f)
        //{
        //    return false;
        //}

        // calculates the unit circle angle for the line between the ship's center and the planet.
        Vector3 shipPointer = ship.transform.position - gameObject.transform.position;
        float shipPointerAngle = Vector3.AngleBetween(Vector3.right, shipPointer);

        // calculates the unit circle angle for the ship's direction.
        Vector3 shipDirection = ship.transform.up;
        float shipDirectionAngle = Vector3.AngleBetween(Vector3.right, shipDirection);

        float theta = Mathf.Abs(shipPointerAngle - shipDirectionAngle);

        return theta < 10f;
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
