using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public GameObject MinimapRawImage;
    public Texture MainCameraRenderTexture;
    public Texture MinimapRenderTexture;
    private Texture GetTexture;

    void Start()
    {
        GetTexture = MinimapRawImage.GetComponent<RawImage>().texture;
    }

    public void SwitchCameraFunction()
    {
        if (GetTexture == MinimapRenderTexture)
            GetTexture = MainCameraRenderTexture;
        else GetTexture = MinimapRenderTexture;
    }
}
