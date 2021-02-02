using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour

{
    public Camera MercuryLanderCamera;
    public Camera VenusLanderCamera;
    public Camera EarthLanderCamera;
    public Camera MarsLanderCamera;
    public Camera JupiterLanderCamera;
    public Camera SaturnLanderCamera;
    public Camera UranusLanderCamera;
    public Camera NeptuneLanderCamera;
    public Camera MainCamera;

    // Update is called once per frame
    private void Start()
    {

        MercuryLanderCamera.gameObject.SetActive(false);
        VenusLanderCamera.gameObject.SetActive(false);
        EarthLanderCamera.gameObject.SetActive(false);
        MarsLanderCamera.gameObject.SetActive(false);
        JupiterLanderCamera.gameObject.SetActive(false);
        SaturnLanderCamera.gameObject.SetActive(false);
        UranusLanderCamera.gameObject.SetActive(false);
        NeptuneLanderCamera.gameObject.SetActive(false);
        MainCamera.gameObject.SetActive(true);

    }
    void Update()
    {
        HandleZoom();
    }

    private void HandleZoom()
    {
        float fov = MainCamera.orthographicSize;
        fov -= Input.GetAxis("Mouse ScrollWheel") * 15;
        fov = Mathf.Clamp(fov, 1, 100);
        MainCamera.orthographicSize = fov;
    }
}