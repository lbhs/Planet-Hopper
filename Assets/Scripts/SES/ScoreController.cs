using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private GameObject info;
    public int id;

    void Start()
    {
        info = GameObject.Find("Info");
        ScoreEvents.current.onLanding += OnLanding;
        ScoreEvents.current.onLeaving += OnLeaving;
    }

    private void OnLanding(int id)
    {
        if (id == this.id)
        {
            info.GetComponent<InfoScript>().UpdateScore();
        }
    }

    private void OnLeaving(int id)
    {
        if (id == this.id)
        {
            Destroy(gameObject);
        }
    }
}
