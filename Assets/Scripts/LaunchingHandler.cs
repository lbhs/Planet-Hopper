using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingHandler : MonoBehaviour
{
    public Canvas PitStopUI;
    public Canvas GUI;
    public float launchForce = 500f;

    /* `ExitPlanet` is only called by the launch button. It will switch the UIs and
     * remove the fixed joint from the ship.
     */

    public void ExitPlanet()
    {
        PitStopUI.enabled = false;
        GUI.enabled = true;

        LandingHandler.current.isLanded = false;

        LaunchShip();
    }

    private void LaunchShip()
    {
        ShipController.main.pitStopped = false;
        LandingHandler.current.shipRB.freezeRotation = false;

        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * launchForce);
    }
}
