﻿/*
 * OrbitHandler.cs
 * Gavin Gee
 * 
 * This script is a singleton controller script that will put the ship into orbit
 * of a planet. InitiateOrbit is called by `OrbitTrigger.cs` after staying within
 * a planets "Orbit Trigger" for 3 seconds.
 * 
 * While in the "orbiting" state, the player loses control of the ship. The ship's
 * will move in a clockwise fashion
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitHandler : MonoBehaviour
{
    public static OrbitHandler main;

    // public stuff ...
    public GameObject ship;
    public float camSpeed;
    public float orbitSpeed;
    public MeshRenderer debugRenderer;

    public GameObject mercury; // 0
    public GameObject venus;   // 1
    public GameObject earth;   // 2
    public GameObject mars;    // 3
    public GameObject jupiter; // 4
    public GameObject saturn;  // 5
    public GameObject uranus;  // 6
    public GameObject neptune; // 7

    // the planet that the ship is orbiting.
    private GameObject planet;

    // important numbers
    private float pos;
    private float radius;

    // signage coefficients for the orbit maths in `UpdateOrbitPosition`
    private int sx = 1;
    private int sy = 1;

    // smoooooth camera vars
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
        if (debugRenderer)
        {
            debugRenderer.enabled = false;
        }

        TShipController.main.ImmobilizeShip();

        AssignPlanet(ID);
        
        CalculateInitialOrbitPosition();
    }

    /* This function calculates the ship's position on the unit circle in radians
     * and sets that value to `pos`. It also finds the `radius` of the ship to
     * the planet.
     */
    private void CalculateInitialOrbitPosition()
    {
        float x = ship.transform.position.x - planet.transform.position.x;
        float y = ship.transform.position.y - planet.transform.position.y;

        // Edge case for if y = 0 so that arctan isn't undefined...
        if (y == 0)
        {
            y += 0.01f;
        }

        pos = Mathf.Atan(x/y);

        // THIS FIXED A HORRIBLE BUG AND I DON'T KNOW WHY. WE TAKE THOSE
        if (y < 0)
        {
            sx = -1;
            sy = -1;
        }

        radius = Vector3.Distance(ship.transform.position, planet.transform.position);

        Debug.Log("Ship @ (" + x + ", " + y + ") relative to planet, " + pos + " in Radians.");
    }

    /* This function to interpolates the camera to a position over the planet using
     * `tCam` as its interpolater.
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
            Debug.Log("Done lerping Main Camera to Planet.");
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

        // otherwise update the ship's orbit
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


    /* This function update's the ship's position in it's orbit around a planet,
     * assuming that the ship has a planet to orbit around. 
     */
    private void UpdateOrbitPosition()
    {
        ship.transform.position = new Vector3(
            planet.transform.position.x + sx * (radius * Mathf.Sin(pos += (orbitSpeed * Time.deltaTime))),
            planet.transform.position.y + sy * (radius * Mathf.Cos(pos += (orbitSpeed * Time.deltaTime))),
            0);
    }

    /* Assigns the `planet` variable its GameObject based on the ID from
     * the Orbit Trigger. 
     * 
     * Note: There's probably a better way of doing this, like using an 
     * array or something. Actually that would be so much easier. I'll get
     * to that later.
    */
    private void AssignPlanet(int ID)
    {
        string debugNameOfPlanet;
        switch (ID)
        {
            case 0:
                debugNameOfPlanet = "Mercury";
                planet = mercury;
                break;
            case 1:
                debugNameOfPlanet = "Venus";
                planet = venus;
                break;
            case 2:
                debugNameOfPlanet = "Earth";
                planet = earth;
                break;
            case 3:
                debugNameOfPlanet = "Mars";
                planet = mars;
                break;
            case 4:
                debugNameOfPlanet = "Jupiter";
                planet = jupiter;
                break;
            case 5:
                debugNameOfPlanet = "Saturn";
                planet = saturn;
                break;
            case 6:
                debugNameOfPlanet = "Uranus";
                planet = uranus;
                break;
            case 7:
                debugNameOfPlanet = "Neptune";
                planet = neptune;
                break;
            default:
                debugNameOfPlanet = "An invalid planet!";
                break;
        }
        Debug.Log("Putting the ship into orbit of " + debugNameOfPlanet);
    }
}
