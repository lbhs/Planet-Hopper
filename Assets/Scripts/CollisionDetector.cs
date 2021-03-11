using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // List of Obstacles in lander game
    public List<GameObject> Rocks;
    public GameObject LanderController;
    public List<GameObject> Floors;

    void OnCollisionEnter(Collision col)
    {
        if (Rocks.Contains(col.gameObject))
        {
            LanderController.GetComponent<LanderController>().Collided = true;
        }
        if (Floors.Contains(col.gameObject))
        {
            LanderController.GetComponent<LanderController>().Completed = true;
            LanderController.GetComponent<LanderController>().Collided = true;
        }
    }
}
