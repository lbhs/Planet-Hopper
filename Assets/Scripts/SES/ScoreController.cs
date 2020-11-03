using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private GameObject info; 
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("Info");
        ScoreEvents.current.onLanding += OnLanding;
        ScoreEvents.current.onLeaving += OnLeaving;
    }

    private void OnLanding()
    {
        info.GetComponent<InfoScript>().UpdateScore();
    }

    private void OnLeaving()
    {
        Destroy(gameObject);
    }
}
