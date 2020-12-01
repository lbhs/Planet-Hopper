using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShipGravity : MonoBehaviour
{


    [SerializeField] public float G;
    public List<Rigidbody> planets = new List<Rigidbody>();
    // Update is called once per frame

    void Start()
    {

    }
    void FixedUpdate()
    {
        Attract();
    }

    void Attract()
    {
        List<float> forces = new List<float>();
        List<Vector3> forcesV = new List<Vector3>();

        foreach (Rigidbody planet in planets)

        {
            Vector3 direction = planet.position - GameObject.Find("Starship").GetComponent<Rigidbody>().position;
            float distance = direction.magnitude;

            float forceMagnitude = (G * GameObject.Find("Starship").GetComponent<Rigidbody>().mass * planet.mass) / Mathf.Pow(distance, 2);
            Vector3 force = direction.normalized * forceMagnitude;

            forces.Add(forceMagnitude);
            forcesV.Add(force);
        }

        var maxForce = forces.Max<float>();

        GameObject.Find("Starship").GetComponent<Rigidbody>().AddForce(forcesV[forces.IndexOf(forces.Max<float>())]);

//        print(planets[forces.IndexOf(forces.Max<float>())]);

        forces.Clear();
        forcesV.Clear();

    }

}

