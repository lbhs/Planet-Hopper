/*
 * OrbitHandler.cs
 * Gavin Gee
 * 
 * This script is a singleton controller script that will put the ship into orbit
 * of a planet. InitiateOrbit is called by `OrbitTrigger.cs` after staying within
 * a planets "Orbit Trigger" for 3 seconds.
 * 
 * While in the "orbiting" state, the player loses control of the ship. 
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitHandler : MonoBehaviour
{
    public static OrbitHandler main;

    public GameObject ship;
    public float camSpeed;
    public float orbitSpeed;
    public MeshRenderer debugRenderer;

    private GameObject planet;

    private float pos;
    private float radius;

    private float tCam = 0;
    private bool camReachedPlanet = false;

    void Start()
    {
        main = this;
    }

    /* This function puts the ship into the "orbiting" state.
     */
    public void InitiateOrbit(int ID)
    {
        debugRenderer.enabled = false;
        TShipController.main.ImmobilizeShip();

        string debugNameOfPlanet;
        switch (ID)
        {
            case 0: debugNameOfPlanet = "Earth";
                planet = GameObject.Find("Earth");
                break;
            default: debugNameOfPlanet = "An invalid planet!";
                break;
        }
        Debug.Log("Putting the ship into orbit of " + debugNameOfPlanet);
        
        CalculateInitialOrbitPosition();
    }

    /* This function calculates the ship's position on the unit circle in radians
     * and sets that value to `pos`. It also finds the `radius` of the ship to
     * the planet.
     */
    private void CalculateInitialOrbitPosition()
    {
        float x = planet.transform.position.x - ship.transform.position.x; // ship.transform.position.x - planet.transform.position.x;
        float y = planet.transform.position.y - ship.transform.position.y; // ship.transform.position.y - planet.transform.position.y;



        pos = Mathf.Atan(x/y);
        radius = Vector3.Distance(ship.transform.position, planet.transform.position);

        Debug.Log("Ship @ (" + x + ", " + y + ") relative to planet, " + pos + " in Radians.");
    }

    /* This function to interpolates the camera to a position over the planet using
     * `tCam` as its interpolater.
     * 
     */
    private void SetOrbitCamera()
    {
        // interpolate
        Camera.main.transform.position = Vector3.Lerp(
            Camera.main.transform.position,
            new Vector3(planet.transform.position.x, planet.transform.position.y, -10f),
            tCam);

        // update camera interpolater for next iteration
        tCam += camSpeed * Time.deltaTime;

        // update `camReachedPlanet` if we reached the planet
        camReachedPlanet = CheckCameraPosition();
    }

    /* Checks if the Camera has reached it's destination. 
     * (If tCam == 1, that means it's done Lerping).
     */
    private bool CheckCameraPosition()
    {
        if (tCam > 1)
        {
            Debug.Log("Done Lerping to Planet.");
            return true;
        }
        return false;
    }

    /* The ship's position in the orbit is managed here.
     */
    public void FixedUpdate()
    {
        // can't progress the orbit if there's no planet ...
        if (!planet) return;

        // orbit ??
        else
        {
            UpdateOrbitPosition();
        }

        // lerp camera if needed
        if (!camReachedPlanet)
        {
            SetOrbitCamera();
        }
    }

    private void UpdateOrbitPosition()
    {
        ship.transform.position = new Vector3(
            planet.transform.position.x + (radius * Mathf.Sin(pos += (orbitSpeed * Time.deltaTime))),
            planet.transform.position.y + (radius * Mathf.Cos(pos += (orbitSpeed * Time.deltaTime))),
            0);
    }
}
