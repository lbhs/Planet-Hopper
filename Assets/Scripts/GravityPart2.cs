using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPart2 : MonoBehaviour
{


    [SerializeField] public float G;

    [SerializeField] public float InitialDistance;

    private void Start()
    {
        int RandomInt = Random.Range(1, 5);
        if (RandomInt == 1)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, Mathf.Sqrt((G * GameObject.Find("Sun").GetComponent<Rigidbody>().mass) / InitialDistance), 0);

            this.GetComponent<Rigidbody>().position = new Vector3(InitialDistance, 0, 0);
        }

        if (RandomInt == 2)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3( -( Mathf.Sqrt((G * GameObject.Find("Sun").GetComponent<Rigidbody>().mass) / InitialDistance)), 0 , 0);

            this.GetComponent<Rigidbody>().position = new Vector3(0, InitialDistance, 0);
        }

        if (RandomInt == 3)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, -(Mathf.Sqrt((G * GameObject.Find("Sun").GetComponent<Rigidbody>().mass) / InitialDistance)), 0);

            this.GetComponent<Rigidbody>().position = new Vector3(-InitialDistance, 0, 0);
        }

        if (RandomInt == 4)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sqrt((G * GameObject.Find("Sun").GetComponent<Rigidbody>().mass) / InitialDistance), 0, 0);

            this.GetComponent<Rigidbody>().position = new Vector3(0, -InitialDistance, 0);
        }



    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        Attract(this.GetComponent<Rigidbody>());
    }

    void Attract (Rigidbody objToAttract)
    {

        Vector3 direction = GameObject.Find("Sun").GetComponent<Rigidbody>().position - this.GetComponent<Rigidbody>().position;
        float distance = direction.magnitude;

        float forceMagnitude = (GameObject.Find("Sun").GetComponent<Rigidbody>().mass * this.GetComponent<Rigidbody>().mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        this.GetComponent<Rigidbody>().AddForce(force);

    }

}
