using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{

    float rotationspeed = 50.0f;
    private Rigidbody gm;
    public float Fuel;
    private Text T;

    private void Start()
    {
        Fuel = 100;
        gm = GetComponent<Rigidbody>();
        T = GameObject.Find("FuelValue").GetComponent<Text>();
    }
    void FixedUpdate()
    {

        float vertical = Input.GetAxis("Vertical");
        gm.GetComponent<Rigidbody>().transform.Rotate(0, 0, -Input.GetAxis("Horizontal")/2);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Fuel = (Fuel - .005f);
            T.text = "Fuel: " + Fuel;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            Fuel = (Fuel - .005f);
            T.text = "Fuel: " + Fuel;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gm.GetComponent<Rigidbody>().AddForce(transform.up);
            Fuel = (Fuel - .01f);
            T.text = "Fuel: " + Fuel;
        }

    }

}