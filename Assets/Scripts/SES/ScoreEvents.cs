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

    public event Action onLanding;
    public void Landing()
    {
        onLanding?.Invoke();
    }

    public event Action onLeaving;
    public void Leaving()
    {
        onLeaving?.Invoke();
    }
}
