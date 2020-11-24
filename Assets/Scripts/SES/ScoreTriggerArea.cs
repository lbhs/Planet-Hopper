/*
 * ScoreTriggerArea.cs
 * Written by Gavin
 * 
 * This script is to be put on landing triggers. When a ship enters the trigger,
 * the script will check if it is a valid landing.
 * 
 * The function `CheckLanding` considers a landing successful if:
 * - The ship is moving less than ``
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerArea : MonoBehaviour
{ 
    public int id;

    private GameObject ship;
    [SerializeField] private float speedLimit;
    [SerializeField] private float angleLimit;

    private void Awake()
    {
        ship = GameObject.Find("Starship");
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.name == ship.name)
        {
            //Debug.Log("Trigger Entered.");
            if (CheckLanding())
            {
                ScoreEvents.current.Landing(id);
            }
            else
            {
                Explode(ship);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == ship)
        {
            Debug.Log("Trigger Exited.");
            ScoreEvents.current.Leaving(id);
        }
    }

    // checks if a landing is valid...
    /*
     * valid landing needs to:
     * - be under a certain speed ( < `speedLimit` m/s )
     * - be rotated away from the planet ( < 'angleLimit' degrees )
     */
    private bool CheckLanding()
    {
        // checks the speed of the ship
        if (ship.GetComponent<Rigidbody>().velocity.magnitude > speedLimit)
        {
            return false;
        }

        // calculates the unit circle angle for the line between the ship's center and the planet.
        Vector3 shipPointer = ship.transform.position - gameObject.transform.position;
        float shipPointerAngle = Vector3.Angle(Vector3.right, shipPointer);
        if (ship.transform.position.y < gameObject.transform.position.y)
        {
            shipPointerAngle = -shipPointerAngle;
        }
        //Debug.Log("ship pointer ang: " + shipPointerAngle);

        // calculates the unit circle angle for the ship's direction.
        Vector3 shipDirection = ship.transform.up;
        float shipDirectionAngle = Vector3.Angle(Vector3.right, shipDirection);
        if (shipDirection.y < 0)
        {
            shipDirectionAngle = -shipDirectionAngle;
        }
        //Debug.Log("ship dir ang: " + shipDirectionAngle);

        // the difference between those two angles
        float deltaTheta = Mathf.Abs(shipPointerAngle - shipDirectionAngle);

        return deltaTheta < angleLimit;
    }

    void Explode(GameObject toDestroy)
    {
        GameObject Explosion = GameObject.Find("Explosion"); //.GetComponent<ParticleSystem>();
        Explosion.transform.position = ship.transform.position;

        ParticleSystem Exploder = Explosion.GetComponent<ParticleSystem>();
        Exploder.Play();
        Destroy(toDestroy);
    }
}
