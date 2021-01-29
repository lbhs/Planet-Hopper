using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] private Camera cam;


    // Update is called once per frame
    void Update()
    {
        HandleZoom();
    }

    private void HandleZoom()
    {
        float fov = cam.orthographicSize;
        fov -= Input.GetAxis("Mouse ScrollWheel") * 15;
        fov = Mathf.Clamp(fov, 1, 100);
        cam.orthographicSize = fov;
    }
}