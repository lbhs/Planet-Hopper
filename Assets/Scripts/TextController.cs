using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text t;
    public GameObject b;
    //public GameObject b2;
    public Toggle camToggle;

    // sorry I'll fix this later...

    public void UpdateMyTextTo(string s)
    {
        t.text = s;
    }

    public void ToggleVisibility()
    {
        t.enabled = !t.enabled;
        b.active = !b.active;
        //b2.active = !b2.active;
        if (camToggle.isOn)
        {
            camToggle.isOn = false;
        } 
    }
}
