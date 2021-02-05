/* 
 * TShipController.cs
 * Written by Gavin (and sorta sam)
 * 
 * This script is a lightweight version of ShipController.cs
 * built for use in the games' tutorials.
 * 
 * It SHOULD feel just like the one in game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShipController : MonoBehaviour
{
    public static TShipController main;

    // ship's RB
    public Rigidbody rb;

    // static vars
    private static float rotationSpeed = 50.0f;
    private static float thrusterForce = .5f;

    // used for sound / vfx
    public AudioSource thrusterSound;
    public ParticleSystem flameEmitter;

    // Start is called before the first frame update
    void Start()
    {
        main = this;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // sound / vfx
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!thrusterSound.isPlaying)
            {
                thrusterSound.Play();
                flameEmitter.Play();
            }
        }
        else
        {
            thrusterSound.Stop();
            flameEmitter.Stop();
        }

        // rotation
        rb.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed);

        // thrusters
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * thrusterForce);
        }
    }
}
