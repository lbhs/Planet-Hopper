using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public bool targetShip = false;
    public GameObject target;

    // in the beginning, the ship will be the target.
    void Start()
    {
        target = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere of Influence")
        {
            Debug.Log("SOI Entered.");
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Sphere of Influence")
        {
            Debug.Log("SOI Exited.");
            target = gameObject;
        }
    }

}
