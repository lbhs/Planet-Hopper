using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShipGravity : MonoBehaviour
{


    [SerializeField] public float G;
    public List<Rigidbody> planets = new List<Rigidbody>();
    public Rigidbody starshipRigidBody;
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
            Vector3 direction = planet.position - starshipRigidBody.position;
            float distance = direction.magnitude;

            float forceMagnitude = (G * starshipRigidBody.mass * planet.mass) / Mathf.Pow(distance, 2);
            Vector3 force = direction.normalized * forceMagnitude;

            forces.Add(forceMagnitude);
            forcesV.Add(force);
            Debug.Log(planet);
        }

        var maxForce = forces.Max<float>();

        starshipRigidBody.AddForce(forcesV[forces.IndexOf(forces.Max<float>())]);


        forces.Clear();
        forcesV.Clear();

    }

}

