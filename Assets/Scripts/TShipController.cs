/* 
 * TShipController.cs
 * Written by Gavin (and sorta sam)
 * 
 * This script is a lightweight version of ShipController.cs
 * built for use in the game's tutorials.
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

    // determines whether player can control the ship;
    private bool inCutScene = false;

    // static vars
    private static float rotationSpeed = 2f;
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
        if (inCutScene) {
            return;
        } 

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

        if (inCutScene)
        {
            return;
        }

        // rotation
        rb.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed);

        if (inCutScene)
        {
            return;
        }

        // thrusters
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * thrusterForce);
        }
    }

    public IEnumerator Launch()
    {
        inCutScene = true;
        Debug.Log("Launching ...");

        rb.velocity = 3f * Vector3.down;

        thrusterSound.Play();
        flameEmitter.Play();

        yield return new WaitForSeconds(2);

        thrusterSound.Stop();
        flameEmitter.Stop();
    }

    public void ImmobilizeShip()
    {
        rb.isKinematic = true;
        if (thrusterSound.isPlaying || flameEmitter.isPlaying)
        {
            thrusterSound.Stop();
            flameEmitter.Stop();
        }
        inCutScene = true;
    }

    public void MobilizeShip()
    {
        rb.isKinematic = false;
        inCutScene = true;
    }
}
