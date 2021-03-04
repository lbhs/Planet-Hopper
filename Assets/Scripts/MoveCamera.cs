using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static MoveCamera main;
    // This will always be the position of the rocketship.
    Transform RocketPosition;

    // This will be the position of whatever the camera is targeting.
    Transform Target;

    // The main camera
    Camera Cam;

    bool followShip;

    bool cameraLerping;

    private const int defaultCamSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        main = this;

        RocketPosition = gameObject.transform;
        Target = RocketPosition;
        Cam = Camera.main;
        followShip = true;
        cameraLerping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraLerping) return;

        // update camera position to ship...
        Cam.transform.position = new Vector3(Target.position.x, Target.position.y, -20);
    }

    // If the camera enters a Sphere of Influence, it will target that planet... (1/2)
    private void OnTriggerEnter(Collider other)
    {
        // TODO: clean up this code and document...
        if (other.name == "SOI")
        {
            Debug.Log("SOI Entered.");
            string planet = other.gameObject.transform.parent.name;
            int zoomedCamSize = getZoomedCamSize(planet);

            Cam.orthographicSize = zoomedCamSize;
            Target = other.gameObject.transform;
            Cam.transform.position = new Vector3(Target.position.x, Target.position.y, 0); // -20);
        }
    }

    // ... until that Sphere of Influence is exited. (2/2)
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "SOI")
        {
            Debug.Log("SOI Exited.");
            Target = RocketPosition;
            Cam.orthographicSize = defaultCamSize;
        }
    }

    private int getZoomedCamSize(string planet)
    {
        switch (planet)
        {
            case "Mercury": return 10;
            case "Venus": return 15;
            case "Earth": return 12;
            case "Mars": return 10;
            case "Jupiter": return 27;
            case "Saturn": return 26;
            case "Uranus": return 20;
            case "Neptune": return 20;
            default: return defaultCamSize;
        }
    }

    public void ToggleFollowShip()
    {
        followShip = !followShip;

        if (followShip)
        {
            Target = RocketPosition;
            Cam.orthographicSize = defaultCamSize;
        }
        else
        {
            Target = OrbitHandler.main.Planet.transform;
            int zoomedCamSize = getZoomedCamSize(OrbitHandler.main.Planet.name);
            Cam.orthographicSize = zoomedCamSize;
        }
    }

    public void ToggleCameraLerping()
    {
        cameraLerping = !cameraLerping;
    }
}
