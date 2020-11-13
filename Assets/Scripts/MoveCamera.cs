﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // This will always be the position of the rocketship.
    Transform RocketPosition;

    // This will be the position of whatever the camera is targeting.
    Transform Target;

    // The main camera
    Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        RocketPosition = gameObject.transform;
        Target = RocketPosition;
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Cam.transform.position = new Vector3(Target.position.x, Target.position.y, -20);
    }

    // If the camera enters a Sphere of Influence, it will target that planet... (1/2)
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere of Influence")
        {
            Debug.Log("SOI Entered.");
            Target = other.gameObject.transform;
            Cam.transform.position = new Vector3(Target.position.x, Target.position.y, -20);
            Target.gameObject.GetComponent<GenerateLandingZones>().OpenLZs();
        }
    }

    // ... until that Sphere of Influence is exited. (2/2)
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Sphere of Influence")
        {
            Debug.Log("SOI Exited.");
            Target = RocketPosition;
        }
    }
}