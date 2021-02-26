using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text t;
    public GameObject b;

    // sorry I'll fix this later...

    public void UpdateMyTextTo(string s)
    {
        t.text = s;
    }

    public void ToggleVisibility()
    {
        t.enabled = !t.enabled;
        b.active = !b.active;
    }
}
