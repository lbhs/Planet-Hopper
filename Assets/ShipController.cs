using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    float rotationspeed = 50.0f;

    void Update()
    {

        float vertical = Input.GetAxis("Vertical");
        GameObject.Find("Cube").GetComponent<Rigidbody>().transform.Rotate(0, 0, -Input.GetAxis("Horizontal")/4);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            GameObject.Find("Cube").GetComponent<Rigidbody>().AddForce(transform.up/4);
        }

    }

}