using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public GameObject MinimapRawImage;
    public Texture MainCameraRenderTexture;
    public Texture MinimapRenderTexture;
    public Toggle CameraToggle;
    public Camera MainCamera;
    public Camera MinimapCamera;

    void Start()
    {
        CameraToggle.GetComponent<Toggle>().isOn = false;
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
}
