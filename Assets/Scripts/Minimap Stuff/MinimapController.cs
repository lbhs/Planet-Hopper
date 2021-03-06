﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    public GameObject MinimapRawImage;
    public Texture MainCameraRenderTexture;
    public Texture MinimapRenderTexture;
    public Toggle CameraToggle;
    public Camera MainCamera;
    public Camera MinimapCamera;

    private bool UpdateMenu;
    public Camera cam;
    private float camsize;
    public Text SelectedPlanet;
    public GameObject panel;
    public GameObject Starship;
    public Text RelativeVelocity;
    public Text Distance;
    public Image Arrow;
    public Image Arrow2;
    public Image Mercury;
    public Image Venus;
    public Image Earth;
    public Image Mars;
    public Image Jupiter;
    public Image Saturn;
    public Image Uranus;
    public Image Neptune;
    public List<GameObject> Planets;
    public List<Text> PlanetNames;
    public Camera MinimapCam;


    void Start()
    {
        CameraToggle.GetComponent<Toggle>().isOn = false;
        Mercury.enabled = false;
        Venus.enabled = false;
        Earth.enabled = false;
        Mars.enabled = false;
        Jupiter.enabled = false;
        Saturn.enabled = false;
        Uranus.enabled = false;
        Neptune.enabled = false;
        panel.SetActive(false);
        UpdateMenu = true;
        camsize = 650;
    }

    public void FixedUpdate()
    {
        if (CameraToggle.GetComponent<Toggle>().isOn == true)
        {
            MinimapRawImage.GetComponent<RawImage>().texture = MainCameraRenderTexture;
            MinimapCamera.enabled = true;
            MainCamera.enabled = false;
        }
        if (CameraToggle.GetComponent<Toggle>().isOn == false)
        {
            MinimapRawImage.GetComponent<RawImage>().texture = MinimapRenderTexture;
            MinimapCamera.enabled = false;
            MainCamera.enabled = true;
        }
    }

    void Update()
    {
        if (CameraToggle.GetComponent<Toggle>().isOn == true)
        {
            camsize -= Input.GetAxis("Mouse ScrollWheel") * 100;
            camsize = Mathf.Clamp(camsize, 600, 900);
            cam.orthographicSize = camsize;
            if (Input.GetMouseButton(0))
            {
                var my = Input.GetAxis("Mouse Y");
                var mx = Input.GetAxis("Mouse X");
                var cy = cam.transform.position.y;
                var newcy = cy - my * 10;
                var cx = cam.transform.position.x;
                var newcx = cx - mx * 10;
                var cz = cam.transform.position.z;
                var cyclamp = Mathf.Clamp(newcy, -300, 300);
                var cxclamp = Mathf.Clamp(newcx, -300, 300);
                cam.transform.position = new Vector3(cxclamp, cyclamp, cz);
            }

            foreach (Text text in PlanetNames)
            {
                text.enabled = true;
                var index = PlanetNames.IndexOf(text);
                var planet = Planets[index];
                var uipos = MinimapCam.WorldToScreenPoint(planet.transform.position);
                var width = Screen.width;
                UnityEngine.Debug.Log(width);
                var newx = uipos.x + 120 * width/1000;
                var newxy = new Vector2(newx, uipos.y);
                text.transform.position = newxy;
                text.color = Color.white;
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermask = 1 << 8;
            if (Physics.Raycast(ray, out hit, 10000, layermask))
            {
                
                var planet = hit.collider.transform.root.gameObject;
                var index = Planets.IndexOf(planet);
                var text = PlanetNames[index];
                text.color = Color.green;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 10000, layermask))
                {
                    DisplayInfo(hit);
                }
            }
        }
        else
        {
            foreach (Text text in PlanetNames)
            {
                text.enabled = false;
            }
        }
    }
    void DisplayInfo(RaycastHit hit)
    {
        panel.SetActive(true);
        var planet = hit.collider.transform.root.gameObject;
        SelectedPlanet.text = planet.name;
        Mercury.enabled = false;
        Venus.enabled = false;
        Earth.enabled = false;
        Mars.enabled = false;
        Jupiter.enabled = false;
        Saturn.enabled = false;
        Uranus.enabled = false;
        Neptune.enabled = false;
        StopCoroutine("ShowInfo");
        StartCoroutine("ShowInfo", planet);
    }

    IEnumerator ShowInfo(GameObject planet)
    {
        while (UpdateMenu == true && Starship != null)
        {
            if (planet.name == "Mercury")
            {
                Mercury.enabled = true;
            }
            if (planet.name == "Venus")
            {
                Venus.enabled = true;
            }
            if (planet.name == "Earth")
            {
                Earth.enabled = true;
            }
            if (planet.name == "Mars")
            {
                Mars.enabled = true;
            }
            if (planet.name == "Jupiter")
            {
                Jupiter.enabled = true;
            }
            if (planet.name == "Saturn")
            {
                Saturn.enabled = true;
            }
            if (planet.name == "Uranus")
            {
                Uranus.enabled = true;
            }
            if (planet.name == "Neptune")
            {
                Neptune.enabled = true;
            }

            yield return new WaitForSeconds(1);
            var starshippos = Starship.transform.position;
            var starshipspeed = Starship.GetComponent<Rigidbody>().velocity;
            var distance = Vector3.Distance(starshippos, planet.transform.position);
            var speed = starshipspeed - planet.GetComponent<Rigidbody>().velocity;
            Distance.text = "Distance: \n" + distance;
            RelativeVelocity.text = "Relative Velocity: \n" + speed.magnitude;

            // Rotate Direction Arrow
            Vector3 direction = planet.transform.position - starshippos;
            if (direction.x < 0)
            {
                if (direction.y > 0)
                {
                    var angle = 180 - Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                }
                if (direction.y < 0)
                {
                    var angle = Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg + 180;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                }
            }
            else
            {
                if (direction.y > 0)
                {
                    var angle = Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                }
                if (direction.y < 0)
                {
                    var angle = 0 - Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                }
            }

            //Rotate Velocity Arrow
            if (speed.x < 0)
            {
                if (speed.y > 0)
                {
                    var anglee = 180 - Mathf.Atan(Mathf.Abs(speed.y) / Mathf.Abs(speed.x)) * Mathf.Rad2Deg;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
                if (speed.y < 0)
                {
                    var anglee = Mathf.Atan(Mathf.Abs(speed.y) / Mathf.Abs(speed.x)) * Mathf.Rad2Deg + 180;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
            }
            else
            {
                if (speed.y > 0)
                {
                    var anglee = Mathf.Atan(Mathf.Abs(speed.y) / Mathf.Abs(speed.x)) * Mathf.Rad2Deg;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
                if (speed.y < 0)
                {
                    var anglee = 0 - Mathf.Atan(Mathf.Abs(speed.y) / Mathf.Abs(speed.x)) * Mathf.Rad2Deg;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
            }


        }
    }
}
