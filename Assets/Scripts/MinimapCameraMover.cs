using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapCameraMover : MonoBehaviour
{
    public Camera cam;
    public Toggle CameraToggle;
    private float camsize;
    public Text SelectedPlanet;
    // Start is called before the first frame update
    void Start()
    {
        camsize = 810;

    }

    // Update is called once per frame
    void Update()
    {
        if (CameraToggle.GetComponent<Toggle>().isOn == true)
        {
            camsize -= Input.GetAxis("Mouse ScrollWheel") * 40;
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
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layermask = 1 << 8;
            if (Physics.Raycast(ray, out hit, 10000, layermask))
            {
                DisplayInfo(hit);
            }
        }
    }
    void DisplayInfo(RaycastHit hit)
    {
        var name = hit.collider.name;
        if (name.Contains("Mercury"))
        {

        }
        if (name.Contains("Venus"))
        {

        }
        if (name.Contains("Earth"))
        {

        }
        if (name.Contains("Mars"))
        {

        }
        if (name.Contains("Jupiter"))
        {

        }
        if (name.Contains("Saturn for Minimap"))
        {

        }
        if (name.Contains("Uranus"))
        {

        }
        if (name.Contains("Neptune"))
        {

        }
    }
}
