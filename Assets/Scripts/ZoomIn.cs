using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public float zoomFactor;
    private bool isZooming = false;
    private Camera cam;
    private const float INITIAL_FACTOR = 5;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        cam.orthographicSize = zoomFactor;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        cam.transform.position = new Vector3(0, 0, -10);
        cam.orthographicSize = INITIAL_FACTOR;
    }

}
