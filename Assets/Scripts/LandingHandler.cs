/*
 * LandingHandler.cs
 * Written by Gavin
 * 
 * This script is to be put on landing triggers. When a ship enters the trigger,
 * the script will check if it is a valid landing.
 * 
 * The function `CheckLanding` considers a landing successful if:
 * - The ship is moving less than `speedlimit`
 * - The ship lands within `angleLimit` degrees of a line drawn from the center 
 *   of the ship to the center of the planet.
 *   
 * Note: I'm trying to phase out the score event system right now, so there may 
 * be a couple of dated, commented out lines.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingHandler : MonoBehaviour
{ 
    public GameObject ship;
    
    [SerializeField] private float speedLimit;
    [SerializeField] private float angleLimit;

    public Rigidbody shipRB;

    public Canvas GUI;
    public Canvas PitStopUI;
    public Text FuelText;

    private Vector3 shipRelativePos;
    public bool isLanded;

    public static LandingHandler current;
    public AudioSource thrusterSound;

    public GameObject Explosion;

    private void Awake()
    {
        shipRB = ship.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ShipController.main.thrusterSound.Stop();
        current = this;
        if (other.name == ship.name)
        {
            Debug.Log("Landing Trigger Entered.");
            if (CheckLanding())
            {
                InitiateLanding();
                string planet = gameObject.transform.parent.name; // name of the planet landed on
                InfoScript.main.UpdateScore(planet);
            }
            else
            {
                Explode(ship);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == ship.name)
        {
            Debug.Log("Landing Trigger Exited.");
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


    /* This function makes a small explosion effect when the ship's landing is
     * invalid according to `CheckLanding` 
     */
    private void Explode(GameObject toDestroy)
    {
        Explosion.transform.position = ship.transform.position;

        // "explode" the ship by disabling components
        ParticleSystem Exploder = Explosion.GetComponent<ParticleSystem>();
        Exploder.Play();
        StartCoroutine(EndGame());

        Destroy(ship);

        //ship.GetComponent<Collider>().enabled = false;
        // ship.GetComponent<Renderer>().enabled = false;

        // Load the next scene.
        
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);

        DontDestroyOnLoad(InfoScript.main.gameObject); // keeps the "Info" gameobject alive
        SceneManager.LoadScene(2); // Load the end scene.
    }

    /* This function handles the player's interactions while landed on a planet.
     * 
     * This function will:
     * 
     * 1. stop the rocket and connect it to the planet. The rocket will be imobile
     *    on the planet's surface.
     *    
     * 2. open a UI menu for the player to interact with. In this menu, the player can:
     *    - refuel their ship
     *    - press a "Launch" button to continue playing.
     *    - (hear a fact about the planet they're on ?)
     *    
     * 3. When "Launch" is selected, some force will be applied to ship, launching it
     *    into (orbit ?) space so the player can continue playing.
     *    
     */
    private void InitiateLanding()
    {
        /* First, make the ship stop moving. I think the play here is to make the ship's velocity
         * Vector3.zero and then make the ship a child of the planet until it needs to leave, but
         * I can also envision it being a pain to do so. I'm not yet sure if this is possible.
         */

        FreezeShip();

        /* Next, open a temporary UI menu. The main features are a "Refuel" and a "Launch" button. 
         * other things like a map, planet facts, etc. can come later if time allows.
         */

        // disables normal game UI and enables Pit Stop UI
        GUI.enabled = false;
        FuelText.text = "Your fuel is currently: " + ShipController.main.Fuel;

        PitStopUI.enabled = true;


        /* Finally, When the player selects "Launch", the ship needs to be sent back into space/orbit.
         * This should be handled by another function.
         */
    }

    private void FreezeShip()
    {
        Time.timeScale = 0;
        shipRB.velocity = Vector3.zero;
        shipRB.freezeRotation = true;

        shipRelativePos = ship.transform.position - transform.position;
        isLanded = true;

        ShipController.main.pitStopped = true;
    }

    private void FixedUpdate()
    {
        if (!isLanded) return;

        ship.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ship.transform.position = transform.position + shipRelativePos;

    }


}
