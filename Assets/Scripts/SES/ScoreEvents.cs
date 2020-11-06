using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEvents : MonoBehaviour
{
    public static ScoreEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action<int> onLanding;
    public void Landing(int id)
    {
        onLanding?.Invoke(id);
    }

    public event Action<int> onLeaving;
    public void Leaving(int id)
    {
        onLeaving?.Invoke(id);
    }
}
