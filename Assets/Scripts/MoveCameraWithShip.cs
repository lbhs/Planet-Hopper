using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithShip : MonoBehaviour
{
    Transform RocketPosition;

    // Start is called before the first frame update
    void Start()
    {
        RocketPosition = GameObject.Find("Starship").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(RocketPosition.position.x, RocketPosition.position.y, -20);
    }
}
