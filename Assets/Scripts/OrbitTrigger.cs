using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTrigger : MonoBehaviour
{
    public int triggerID;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("OrbitTimer");
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    private IEnumerator OrbitTimer()
    {
        yield return new WaitForSeconds(3);
        OrbitHandler.main.InitiateOrbit(triggerID);
    }
}

