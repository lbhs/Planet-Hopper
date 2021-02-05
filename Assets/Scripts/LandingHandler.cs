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
    [SerializeField] public Camera MainCamera;
    [SerializeField] public Camera LanderCamera;
    public Rigidbody Lander;
    public bool landerLanded = false;
    public bool landingComplete = false;
    public Vector3 initialShipPosition;
    public float launchForce = 500f;
    public GameObject flameEmitter;
    public GameObject mercury;
    public GameObject venus;
    public GameObject earth;
    public GameObject mars;
    public GameObject jupiter;
    public GameObject saturn;
    public GameObject uranus;
    public GameObject neptune;
    public GameObject closestPlanet;



    private void Start()
    {

        Lander.isKinematic = true;

    }
    

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

            InitiateLanding();
            string planet = gameObject.transform.parent.name; // name of the planet landed on
            InfoScript.main.UpdateScore(planet);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == ship.name)
        {
            Debug.Log("Landing Trigger Exited.");
        }
    }

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

        InfoScript.main.gameOverMessage = "You Crashed!";
        InfoScript.main.EndGame(); // Load the end scene.
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

        CheckClosestPlanet();
        shipRB.velocity = Vector3.zero;
        
        shipRB.isKinematic = true;
        //FreezeShip();
        LanderCamera.gameObject.SetActive(true);
        MainCamera.gameObject.SetActive(false);
        // EarthLander.gameObject.GetComponent<Rigidbody>().useGravity = true;
        Lander.isKinematic = false;

        /* Next, open a temporary UI menu. The main features are a "Refuel" and a "Launch" button. 
         * other things like a map, planet facts, etc. can come later if time allows.
         */

        // disables normal game UI and enables Pit Stop UI


        //GUI.enabled = false;
        //FuelText.text = "Your fuel is currently: " + ShipController.main.Fuel;

        //PitStopUI.enabled = true;


        /* Finally, When the player selects "Launch", the ship needs to be sent back into space/orbit.
         * This should be handled by another function.
         */
    }

    private void FreezeShip()
    {
        shipRB.velocity = Vector3.zero;
        shipRB.freezeRotation = true;

        //shipRelativePos = ship.transform.position - transform.position;
        isLanded = true;

        ShipController.main.pitStopped = true;
    }

    private void CheckClosestPlanet()
    {
        GameObject[] planets = { mercury, venus, earth, mars, jupiter, saturn, uranus, neptune };
        foreach (GameObject planet in planets)
        {
            if ((shipRB.transform.position - planet.GetComponent<Rigidbody>().transform.position).magnitude < 30)
            {
                closestPlanet = planet;
            }
        }


    }

    private void FixedUpdate()
    {
        if (!isLanded) return;

        ship.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //ship.transform.position = transform.position + shipRelativePos;

    }

    void Update()
    {

        if (Lander.isKinematic == false)
        {

            Lander.AddForce(0, -0.1f, 0);


            if (Input.GetKey(KeyCode.LeftArrow))
            {

                Lander.transform.Rotate(0, 0, 0.3f);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {

                Lander.transform.Rotate(0, 0, -0.3f);

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {

                Lander.AddForce(Lander.transform.up * 0.2f);

            }

            //if (landerLanded == false)
            //{
            //    Lander.angularVelocity = new Vector3(0, 0, 0);
            //}

            if (Lander.position.y < 1)
            {

                ExitPlanet();

            }


        }



    }


    public void ExitPlanet()
    {
        PitStopUI.enabled = false;
        GUI.enabled = true;
        MainCamera.gameObject.SetActive(true);
        LanderCamera.gameObject.SetActive(false);
        Lander.transform.position = Lander.transform.position + new Vector3(0, 10, 0);
        Lander.transform.rotation = Quaternion.Euler(0, 0, 0);
        Lander.isKinematic = true;
        shipRB.isKinematic = false;
        if (closestPlanet == jupiter ^ closestPlanet == saturn)
            {

            shipRB.transform.position = closestPlanet.transform.position + new Vector3(0, 15, 0);

        }
        else
        {
            shipRB.transform.position = closestPlanet.transform.position + new Vector3(0, 10, 0);
        }
        
        shipRB.transform.rotation = Quaternion.Euler(0, 0, 270);
        shipRB.velocity = new Vector3(3, 0, 0);

        


        LandingHandler.current.isLanded = false;

        LaunchShip();


    }

    IEnumerator runFlames()
    {
        ShipController.main.thrusterSound.Play();
        ShipController.main.flameEmitter.Play();
        ShipController.main.overrideArrow = true;
        yield return new WaitForSeconds(1);
        ShipController.main.flameEmitter.Stop();
        ShipController.main.overrideArrow = false;
        ShipController.main.thrusterSound.Stop();

    }

    private void LaunchShip()
    {
        ShipController.main.pitStopped = false;
        LandingHandler.current.shipRB.freezeRotation = false;

        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * launchForce);
        StartCoroutine(runFlames());

    }



}