// HI MARC

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public float rotationspeed = 50.0f;
    public float fuelDelta = .07f;
    public float baseFuelValue = 5000f;
    public float thrusterForce = .5f;

    private Rigidbody gm;
    public float Fuel;

    // public Text T;
    public Text pitStopText;

    public bool pitStopped = false;
    public bool overrideArrow = false;

    private bool movementLocked = false;

    public AudioSource thrusterSound;
    public ParticleSystem flameEmitter;

    public static ShipController main;

    public Image FuelGuage;
    public float rotation;

    private void Start()
    {
        main = this;
        Fuel = baseFuelValue;
        gm = GetComponent<Rigidbody>();
        // T = GameObject.Find("FuelValue").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (movementLocked) return;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!thrusterSound.isPlaying)
                thrusterSound.Play();
        }

        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (thrusterSound.isPlaying)
                thrusterSound.Stop();
        }
        // if out of fuel, can't rotate or use thrusters.
        if (Fuel <= 0)
        {
            flameEmitter.Stop();
            thrusterSound.Stop();
            return;
        }

        // if at a pit stop, can't rotate or use thrusters.
        if (pitStopped)
        {
            //flameEmitter.Stop();
            return;
        }

        float vertical = Input.GetAxis("Vertical");
        // applies rotation
        gm.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationspeed); //1.5f);

        // adjusts fuel...
        if (!Input.GetKey(KeyCode.UpArrow) && overrideArrow == false)
        {
            if (flameEmitter.isPlaying)
            {
                flameEmitter.Stop();
            }
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

            if (!flameEmitter.isPlaying) {
                flameEmitter.Play();
            }

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
        // T.text = "Fuel: " + Fuel;
        pitStopText.text = "Your fuel is currently: " + Fuel;
    //    rotation = 104.491f - (119.767f * (Fuel / 500f));
        rotation = -15.276f + (119.767f * (1f - Fuel / 500f));
        FuelGuage.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void ImmobilizeShip()
    {
        gm.isKinematic = true;
        if (thrusterSound.isPlaying || flameEmitter.isPlaying)
        {
            thrusterSound.Stop();
            flameEmitter.Stop();
        }
        movementLocked = true;
    }

    public void MobilizeShip(float radius)
    {
        gm.isKinematic = false;
        movementLocked = false;

        // gives the ship a small boost in the direction it's facing

        gm.AddForce(100 * radius * gm.transform.up);
    }
}