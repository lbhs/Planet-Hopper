using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateLandingZones : MonoBehaviour
{
    // the four Landing Zones in this Sphere of Influence
    Transform LZ0;
    Transform LZ1;
    Transform LZ2;
    Transform LZ3;

    public Text LZ0Text;
    public Text LZ1Text;
    public Text LZ2Text;
    public Text LZ3Text;

    Camera cam;

    void Start()
    {
        LZ0 = transform.GetChild(0);
        LZ1 = transform.GetChild(1);
        LZ2 = transform.GetChild(2);
        LZ3 = transform.GetChild(3);

        cam = Camera.main;
    }

    public void OpenLZs()
    {
        LZ0Text.transform.position = cam.WorldToScreenPoint(LZ0.position);
        LZ0.gameObject.GetComponent<MeshRenderer>().enabled = true;

        LZ1Text.transform.position = cam.WorldToScreenPoint(LZ1.position);
        LZ1.gameObject.GetComponent<MeshRenderer>().enabled = true;

        LZ2Text.transform.position = cam.WorldToScreenPoint(LZ2.position);
        LZ2.gameObject.GetComponent<MeshRenderer>().enabled = true;

        LZ3Text.transform.position = cam.WorldToScreenPoint(LZ3.position);
        LZ3.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    //void CloseLZs()
    //{
    //    LZ0Text.transform.position = cam.WorldToScreenPoint(LZ0.position);
    //    LZ1Text.transform.position = cam.WorldToScreenPoint(LZ1.position);
    //    LZ2Text.transform.position = cam.WorldToScreenPoint(LZ2.position);
    //    LZ3Text.transform.position = cam.WorldToScreenPoint(LZ3.position);
    //}
}
