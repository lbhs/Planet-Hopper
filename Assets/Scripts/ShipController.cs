using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{

    float rotationspeed = 50.0f;
    private Rigidbody gm;
    public float Fuel;

    public Text T;
    public Text Speed;
    public Text pitStopText;

    public bool pitStopped = false;
    private bool refueled = false;

    public GameObject flameEmitter;

    public static ShipController main;

    private void Start()
    {
        main = this;
        Fuel = 100;
        gm = GetComponent<Rigidbody>();
        T = GameObject.Find("FuelValue").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        var shipspeed = gm.velocity;
        Speed.text = "Speed: " + shipspeed.magnitude + "m/s";
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
        gm.GetComponent<Rigidbody>().transform.Rotate(0, 0, -Input.GetAxis("Horizontal")/1.5f);

        // adjusts fuel...
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            flameEmitter.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Fuel = (Fuel - .05f);
            UpdateFuelText();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Fuel = (Fuel - .05f);
            UpdateFuelText();
        }

        // applies force... "thrusters"
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gm.GetComponent<Rigidbody>().AddForce(transform.up / 2);
            flameEmitter.SetActive(true);
            Fuel = (Fuel - .1f);
            UpdateFuelText();
        }
    }

    public void Refuel()
    {
        Debug.Log("Refueling...");
        Fuel = 100f;
        refueled = true;
        UpdateFuelText();
    }

    private void UpdateFuelText()
    {
        T.text = "Fuel: " + Fuel;
        pitStopText.text = "Your fuel is currently: " + Fuel;
    }
}