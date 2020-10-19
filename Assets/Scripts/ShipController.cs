using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    float rotationspeed = 50.0f;

    private Rigidbody gm;

    private void Start()
    {
        gm = GetComponent<Rigidbody>();
    }
    void Update()
    {

        float vertical = Input.GetAxis("Vertical");
        gm.GetComponent<Rigidbody>().transform.Rotate(0, 0, -Input.GetAxis("Horizontal")/4);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gm.GetComponent<Rigidbody>().AddForce(transform.up/4);
        }

    }

}