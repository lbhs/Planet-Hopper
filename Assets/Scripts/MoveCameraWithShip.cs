using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithShip : MonoBehaviour
{
    // This will always be the position of the rocketship.
    Transform RocketPosition;

    // This will be the position of whatever the camera is targeting.
    Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        RocketPosition = GameObject.Find("Starship").transform;
        Target = RocketPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Target.position.x, Target.position.y, -20);
    }

    // If the camera enters a Sphere of Influence, it will target that planet... (1/2)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SOI Entered");
        if (other.name == "Sphere of Influence")
        {
            Target = other.gameObject.transform;
        }
    }

    // ... until that Sphere of Influence is exited. (2/2)
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Sphere of Influence")
        {
            Target = RocketPosition;
        }
    }
}
