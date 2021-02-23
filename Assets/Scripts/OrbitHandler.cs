/*
 * OrbitHandler.cs
 * Gavin Gee
 * 
 * This script is a singleton controller script that will put the ship into orbit
 * of a planet. InitiateOrbit is called by `OrbitTrigger.cs` after staying within
 * a planets "Orbit Trigger" for 3 seconds.
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitHandler : MonoBehaviour
{
    public static OrbitHandler main;

    void Start()
    {
        main = this;
    }

    public void InitiateOrbit(int ID)
    {
        string debugNameOfPlanet;
        switch (ID)
        {
            case 0: debugNameOfPlanet = "Earth.";
                break;
            default: debugNameOfPlanet = "An invalid planet!";
                break;
        }
        Debug.Log("Putting the ship into orbit of " + debugNameOfPlanet);
    }
}
