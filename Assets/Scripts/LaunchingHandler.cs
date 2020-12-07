﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingHandler : MonoBehaviour
{
    public Canvas PitStopUI;
    public Canvas GUI;

    /* `ExitPlanet` is only called by the launch button. It will switch the UIs and
     * remove the fixed joint from the ship.
     */

    public void ExitPlanet()
    {
        PitStopUI.enabled = false;
        GUI.enabled = true;

        LaunchShip();
    }

    private void LaunchShip()
    {
        Destroy(gameObject.GetComponent<FixedJoint>());
        ShipController.main.pitStopped = false;

        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 500);
    }
}
