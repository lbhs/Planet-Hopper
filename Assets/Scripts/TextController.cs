using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text t;
    public GameObject b;
    public GameObject b2;
    public Toggle camToggle;

    // sorry I'll fix this later...

    public void UpdateMyTextTo(string s)
    {
        t.text = s;
    }

    public void ToggleVisibility()
    {
        if (b.active == true && b2.active == false)
        {
            t.enabled = !t.enabled;
            b.active = !b.active;
        }
        else {
            t.enabled = !t.enabled;
            b.active = !b.active;
            b2.active = !b2.active;
            if (camToggle.isOn)
            {
                camToggle.isOn = false;
            }
        }

    }

    public void ToggleVisibilityEnd()
    {
        t.enabled = !t.enabled;
        b.active = !b.active;
    }
}
