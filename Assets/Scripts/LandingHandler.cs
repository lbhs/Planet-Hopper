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
    // public Vector3 initialShipPosition;
    public float launchForce = 500f;
    public GameObject flameEmitter;
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;
    public GameObject closestPlanet;
    public GameObject velocityPanel;
    public GameObject minimap;



    private void Start()
    {

        Lander.isKinematic = true;
        MainCamera.gameObject.SetActive(true);
        LanderCamera.gameObject.SetActive(false);
        velocityPanel = GameObject.Find("Closest");
        minimap = GameObject.Find("Minimap");

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



    


    private void InitiateLanding()
    {
        CheckClosestPlanet();
        FreezeShip();
        LanderSetUp();
    }

    private void CheckClosestPlanet()
    {
        Debug.Log(closestPlanet + "this is closest planet");
    }

    private void FreezeShip()
    {
        shipRB.velocity = Vector3.zero;
        shipRB.transform.position = new Vector3(0, 3000, 0);
        shipRB.freezeRotation = true;
        shipRB.isKinematic = true;
    }

    private void LanderSetUp()
    {
        minimap.SetActive(false);
        velocityPanel.SetActive(false);
        LanderCamera.gameObject.SetActive(true);
        MainCamera.gameObject.SetActive(false);
        Lander.isKinematic = false;
        
    }

    private void FixedUpdate()
    {
        if (landerLanded == false)
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
                if (Lander.position.y < .9)
                {
                    if (Lander.velocity.y < -1 || Lander.velocity.x < -1 || (Lander.transform.rotation.eulerAngles.z > 20 && Lander.transform.rotation.eulerAngles.z < 340))
                    {
                        landerLanded = true;
                        
                        Debug.Log(Lander.transform.rotation.eulerAngles.z);
                        StartCoroutine(EndGameFunc());
                    }

                    else
                    {
                        landerLanded = true;
                        ExitPlanet();
                        //PitStopUI.GetComponent<Canvas>().enabled = true;
                    }
                }
            }
        }
        
    }
    IEnumerator EndGameFunc()
    {
        Explode(Lander);
        InfoScript.main.gameOverMessage = "You Crashed!";
        yield return new WaitForSeconds(2);
        landerLanded = false;
        SceneManager.LoadScene(2);
    }
    private void Explode(Rigidbody toDestroy)
    {
        Explosion.transform.position = toDestroy.transform.position;


        ParticleSystem Exploder = Explosion.GetComponent<ParticleSystem>();
        Exploder.Play();
        toDestroy.gameObject.SetActive(false);

    }
    public void ExitPlanet()
    {

        landerLanded = false;
        minimap.SetActive(true);
        //PitStopUI.GetComponent<Canvas>().enabled = false;
        velocityPanel.SetActive(true);
        LanderCamera.gameObject.SetActive(false);
        MainCamera.gameObject.SetActive(true);

        Lander.transform.position = Lander.transform.position + new Vector3(0, 10, 0);
        Lander.transform.rotation = Quaternion.Euler(0, 0, 0);
        Lander.isKinematic = true;
        shipRB.isKinematic = false;

        if (closestPlanet == Jupiter ^ closestPlanet == Saturn)
            {
            Debug.Log(closestPlanet + "this is closest planet2");
            shipRB.transform.position = closestPlanet.transform.position + new Vector3(0, 15, 0);

        }
        else
        {
            Debug.Log(closestPlanet + "this is closest planet3");
            shipRB.transform.position = closestPlanet.transform.position + new Vector3(0, 10, 0);
        }
        
        shipRB.transform.rotation = Quaternion.Euler(0, 0, 270);
        
        shipRB.velocity = new Vector3(3, 0, 0);
        StartCoroutine(runFlames());
        Trail.main.StartTrailCor();
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

}