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

    public GameObject flameEmitter;

    private void Start()
    {
        Fuel = 100;
        gm = GetComponent<Rigidbody>();
        T = GameObject.Find("FuelValue").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        // if out of fuel, can't rotate or use thrusters.
        //if (Fuel <= 0)
        //{
        //    flameEmitter.SetActive(false);
        //    return;
        //}
        
        float vertical = Input.GetAxis("Vertical");
        // applies rotation
        gm.GetComponent<Rigidbody>().transform.Rotate(0, 0, -Input.GetAxis("Horizontal")/1.5f);

        // adjusts fuel...
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            flameEmitter.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Fuel = (Fuel - .05f);
            T.text = "Fuel: " + Fuel;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Fuel = (Fuel - .05f);
            T.text = "Fuel: " + Fuel;
        }

        // applies force... "thrusters"
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gm.GetComponent<Rigidbody>().AddForce(transform.up / 2);
            flameEmitter.SetActive(true);
            Fuel = (Fuel - .1f);
            T.text = "Fuel: " + Fuel;
        }
    }

}