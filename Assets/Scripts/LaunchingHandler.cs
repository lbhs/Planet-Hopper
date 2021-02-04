using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingHandler : MonoBehaviour
{
    public Canvas PitStopUI;
    public Canvas GUI;
    public float launchForce = 500f;
    public GameObject flameEmitter;

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

    IEnumerator runFlames()
    {
        ShipController.main.thrusterSound.Play();
        ShipController.main.flameEmitter.Play();
        ShipController.main.overrideArrow = true;
        yield return new WaitForSeconds(1);
        ShipController.main.flameEmitter.Stop();
        ShipController.main.overrideArrow = false;
        ShipController.main.thrusterSound.Stop();

    }

    private void LaunchShip()
    {
        ShipController.main.pitStopped = false;
        LandingHandler.current.shipRB.freezeRotation = false;

        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * launchForce);
        Time.timeScale = 1;
        StartCoroutine(runFlames());

    }
}
