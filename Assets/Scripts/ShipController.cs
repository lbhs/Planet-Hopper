using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public float rotationspeed = 50.0f;
    public float fuelDelta = .1f;
    public float baseFuelValue = 500f;
    public float thrusterForce = .5f;

    private Rigidbody gm;
    public float Fuel;

    public Text T;
    public Text pitStopText;

    public bool pitStopped = false;
    public bool overrideArrow = false;

    public GameObject flameEmitter;

    public static ShipController main;

    private void Start()
    {
        main = this;
        Fuel = baseFuelValue;
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

        // if at a pit stop, can't rotate or use thrusters.
        if (pitStopped)
        {
            flameEmitter.SetActive(false);
            return;
        }

        float vertical = Input.GetAxis("Vertical");
        // applies rotation
        gm.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationspeed); //1.5f);

        // adjusts fuel...
        if (!Input.GetKey(KeyCode.UpArrow) && overrideArrow == false)
        {
           flameEmitter.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Fuel = (Fuel - fuelDelta);
            UpdateFuelText();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Fuel = (Fuel - fuelDelta);
            UpdateFuelText();
        }

        // applies force... "thrusters"
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gm.AddForce(transform.up * thrusterForce);
            flameEmitter.SetActive(true);
            Fuel = (Fuel - (2 * fuelDelta));
            UpdateFuelText();
        }
    }

    public void Refuel()
    {
        Debug.Log("Refueling...");
        Fuel = baseFuelValue;
        UpdateFuelText();
    }

    private void UpdateFuelText()
    {
        T.text = "Fuel: " + Fuel;
        pitStopText.text = "Your fuel is currently: " + Fuel;
    }
}