/**
 *
 * Gravity.cs
 * Written by Gavin Gee
 *
 * This script can be placed on a Gameobject in Unity and will attract this
 * object to another according to Newton's Law of Gravitational Force with the
 * exception that the force is not mutual among both objects– only the object
 * that this script is on will have a force applied to it. In order to achieve
 * realistic gravitation in which both objects are attracted to each other, this
 * script must be put on both objects and the "Attractor" field in the editor
 * must be set to the target object.
 *
 * Editor Variables:
 *
 *  G: the gravitational constant used in the Gravitational Force equation.
 * 
 *  Attractor Name: the name of the object that will attract this object.
 * 
 *  Initial Velocity: the initial downward force placed on this object. Useful for
 *  simulating orbits.
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Gravitational Constant
    [SerializeField] private float G;

    // the name of the object that will be attracting this object.
    [SerializeField] private string attractorName;
    private GameObject attractor;

    // the initial velocity of the object
    [SerializeField] private float initialVelocity;

    // the rigibody of the object effected by gravity
    private Rigidbody r;
    
    void Start()
    {
        r = this.GetComponent<Rigidbody>();
        attractor = GameObject.Find(attractorName);
        r.velocity = (initialVelocity * Vector3.down);
    }

    void FixedUpdate()
    {
        // declaring the gravitational force on the object
        Vector3 f;

        // calculates the gravitational force on the object
        f = CalculateGravitationalForce(transform.position, this.GetComponent<Rigidbody>().mass);

        // applies that force to the object
        r.AddForce(f);
    }

    private Vector3 CalculateGravitationalForce(Vector3 pos1, float m1) {

        Vector3 attractorLocation = attractor.transform.position;
        float attractorMass = attractor.GetComponent<Rigidbody>().mass;

        // finds the direction of the force
        Vector3 direction = attractorLocation - pos1;

        // finds the distancee between the two gameobjects
        float distance = Vector3.Distance(pos1, attractorLocation);

        // finds the magnitude of the force
        float magnitude = (G * m1 * attractorMass) / (distance * distance);

        // the final force is equal to the magnitude of the force multiplied by the direction
        return magnitude * direction;
    }
}
