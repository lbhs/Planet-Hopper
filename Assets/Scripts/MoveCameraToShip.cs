﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform RocketPosition = GameObject.Find("Starship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(RocketPosition.position.x, RocketPosition.position.y, -20);
    }
}
